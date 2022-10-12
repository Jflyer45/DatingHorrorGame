using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Navigation dateNPC;
    public DialogueManager dm;
    public List<Dialogue> dialogues;
    public GameObject player;

    private bool dateNPCMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        CommandLocation("BarToLane");
    }

    // Update is called once per frame
    void Update()
    {
        //if (!dateNPCMoving)
        //{
            //CommandLocation("LaneToBar");
        //}
    }

    private void CommandLocation(string routeKey)
    {
        dateNPC.ReceiveCommand(routeKey);
    }

    private Dialogue NextDialogue(string agentName)
    {
        //temp code
        if (agentName == "erik")
        {
            return dialogues[0];
        }
        else
        {
            return null;
        }
    }

    // returns true if dialogue was served, else false if no dialogue available.
    public bool ServeDialogue(string agentName)
    {
        //logic to get dialogue, if any, for agent
        Dialogue d = NextDialogue(agentName);

        if (d != null)
        {
            dm.StartDialogue(d);
            return true;
        }
        else
        {
            return false;
        }        
    }

    public void UpdateAgentsMovementState(string npcName, bool state)
    {
        if(npcName == "erik")
        {
            dateNPCMoving = state;
        }
    }
}
