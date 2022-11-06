using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class HorrorBasementBT : MonoBehaviour
{
    private DateNPC dateNPC;
    private Navigation dateNav;
    private FOV fov;

    private bool hasOrderedCommand = false;
    private bool reachedLocation = false;
    void Start()
    {
        dateNPC = GetComponent<DateNPC>();
        dateNav = GetComponent<Navigation>();
        fov = GetComponent<FOV>();
    }

    [Task]
    void CanSeePlayer()
    {
        if (fov.canSeePlayer) { ThisTask.Succeed(); } else { ThisTask.Fail(); }
    }

    [Task]
    void ChasePlayer()
    {
        dateNav.ChasePlayer();
        if (!fov.canSeePlayer)
        {
            dateNav.TESTATTACKPLAYER = false;
            ThisTask.Fail();
        }
    }

    [Task]
    void MoveTo(string location)
    {
        if (!hasOrderedCommand)
        {
            hasOrderedCommand = true;
            dateNav.ReceiveCommand(location, .1f);
        }
        WaitArrival();
    }

    void WaitTillReachedTarget()
    {
        StartCoroutine("IsMoving");
        ThisTask.Succeed();
    }

    [Task]
    void WaitArrival()
    {
        if (reachedLocation)
        {
            hasOrderedCommand = false;
            reachedLocation = false;
            ThisTask.Succeed();
        }
    }

    public void NotifyBT()
    {
        reachedLocation = true;
    }
}
