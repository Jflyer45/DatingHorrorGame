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


    public float cooldown = 3f;
    private float cooldownReset = 3f;
    public bool currentlyChasing = false;
    [Task]
    void ChasePlayer()
    {
        currentlyChasing = true;
        dateNav.ChasePlayer();
        if (!fov.canSeePlayer)
        {
            Debug.Log(Time.deltaTime);
            cooldown = cooldown - Time.deltaTime;
            if(cooldown <= 0)
            {
                Debug.Log("Cool down out" + cooldown);
                dateNav.TESTATTACKPLAYER = false;
                cooldown = cooldownReset;
                currentlyChasing = false;
                ThisTask.Fail();
            }

        }
        else
        {
            cooldown = cooldownReset;
        }
    }

    [Task]
    bool CanSeeOrChasing()
    {
        bool chasing = currentlyChasing;
        bool canSee = fov.canSeePlayer;
        if (canSee || chasing) { ThisTask.Succeed(); return true; } else { ThisTask.Fail(); return false; }
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
