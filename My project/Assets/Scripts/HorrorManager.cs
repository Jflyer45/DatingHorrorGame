using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class HorrorManager : GameManager
{
    private bool isPatrol = true;
    public FOV dateFOV;
    public PandaBehaviour bt;

    void Start()
    {
        playerController.canMove = false;
        StartCoroutine("Intro");
    }

    // Update is called once per frame
    void Update()
    {
        //if(isPatrol && !dateNPCMoving)
        //{
            //NPCPatrol();
        //}
    }

    private IEnumerator Intro()
    {
        CommandLocation("Laundry");
        while (dateNPCNav.IsMoving())
        {
            yield return null;
        }
        ChangeNextDialogue(0);
        ServeDialogue("erik");
        while (dm.HasActiveDialogue())
        {
            yield return null;
        }

        CommandLocation("BottomOfStairs");
        while (dateNPCNav.IsMoving())
        {
            yield return null;
        }

        //Grace time
        yield return new WaitForSeconds(15f);

        //He returns
        CommandLocation("Laundry");
        while (dateNPCNav.IsMoving())
        {
            yield return null;
        }

        Debug.Log("Can  I see the player?");
        //If the player is not there
        if (!dateFOV.canSeePlayer)
        {
            bt.tickOn = BehaviourTree.UpdateOrder.Update;
            //Scream or something
        }
        else
        {
            //Dialogue to kill you
        }
    }
}
