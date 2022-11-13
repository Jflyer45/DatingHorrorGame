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
    public GameObject key;
    public GameObject fakeKey;
    public List<Transform> keyLocations;

    public float gracePeriod = 15f;
    public GameObject rope;
    public AudioSource ropeSound;
    private bool hasCutRope = false;

    void Start()
    {
        this.jumpscareActive = true;
        SetUpItems();
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
                ropeSound.Play();
                rope.SetActive(false);
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
        yield return new WaitForSeconds(gracePeriod);

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

    private void SetUpItems()
    {
        RandomSpawn(key, keyLocations);
        RandomSpawn(fakeKey, keyLocations);
        RandomSpawn(fakeKey, keyLocations);
        RandomSpawn(fakeKey, keyLocations);
        RandomSpawn(fakeKey, keyLocations);
    }

    private void RandomSpawn(GameObject obj, List<Transform> locations)
    {
        int randomIndex = Random.Range(0, locations.Count);
        GameObject insObj = Instantiate(obj);
        insObj.transform.position = locations[randomIndex].transform.position;
        locations.RemoveAt(randomIndex);
    }
}
