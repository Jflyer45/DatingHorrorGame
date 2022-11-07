using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
using TMPro;
public class HorrorManager : GameManager
{
    private bool isPatrol = true;
    public FOV dateFOV;
    public PandaBehaviour bt;
    public GameObject itemHolder;
    public TMP_Text cutRopeIndicator;

    private bool hasCutRope = false;

    void Start()
    {
        TurnGlassIndicatorOff();
        playerController.canMove = false;
        StartCoroutine("Intro");
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasCutRope && CheckIfHoldingGlass())
        {
            TurnGlassIndicatorOn();
            if (Input.GetKeyDown(KeyCode.F))
            {
                hasCutRope = true;
                TurnGlassIndicatorOff();
                playerController.canMove = true;
                //Play rope cut
            }
        }
        else
        {
            TurnGlassIndicatorOff();
        }
    }

    private IEnumerator Intro()
    {
        playerController.canMove = false;
        playerController.canLook = false;
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
        playerController.canMove = false;

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

    private bool CheckIfHoldingGlass()
    {
        Transform[] items = itemHolder.GetComponentsInChildren<Transform>();
        Debug.Log("Is holding " + items[0].tag);

        if(items.Length > 1 && items[1].tag == "GlassShard")
        {
            return true;
        }
        return false;
    }

    private void TurnGlassIndicatorOff()
    {
        cutRopeIndicator.text = "";
    }
    private void TurnGlassIndicatorOn()
    {
        cutRopeIndicator.text = "Press 'F' to cut rope";
    }
}
