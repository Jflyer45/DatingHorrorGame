using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Navigation dateNPCNav;
    public DateNPC dateNPC;
    public DialogueManager dm;
    public List<Dialogue> dialogues;
    public GameObject player;

    private bool dateNPCMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        CommandLocation("LaneToSide");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CommandLocation(string routeKey)
    {
        dateNPCNav.ReceiveCommand(routeKey);
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

    public void ReceivePlayerChoice(int choice, Dialogue d)
    {
        Dictionary<string, List<DialogueEffect>> dialoguesWithEffects = BowlingLaneDialogueEffects.GetDialogueWithEffects();

        Debug.Log("NAME BELOW");
        Debug.Log(d.name);

        if (dialoguesWithEffects.ContainsKey(d.name))
        {
            Debug.Log("Choice: " + choice + " effect: " + dialoguesWithEffects[d.name].ToString());
            DialogueEffect de = dialoguesWithEffects[d.name][choice];
            dateNPC.ChangeMoodLevel(de.moodChange);
            if(de.locationCommand != null)
            {
                CommandLocation(de.locationCommand);
            }
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

    //Used by navigation to tell GM when date npc moving
    public void UpdateAgentsMovementState(string npcName, bool state)
    {
        if(npcName == "erik")
        {
            dateNPCMoving = state;
        }
    }
}
