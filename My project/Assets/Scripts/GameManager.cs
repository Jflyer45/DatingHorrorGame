using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Navigation dateNPCNav;
    public DateNPC dateNPC;
    public DialogueManager dm;
    public List<Dialogue> dialogues; // More specifically conversation starts.
    private int dateNPCDialogueIndex;
    public GameObject player;
    public Dialogue attackDialogue;
    public MusicController MC;

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
            return dialogues[dateNPCDialogueIndex];
        }
        else
        {
            return null;
        }
    }

    private void ChangeNextDialogue(int index)
    {
        dateNPCDialogueIndex = index;
    }

    
    public void ReceivePlayerChoice(int choice, Dialogue d)
    {
        Dictionary<string, List<DialogueEffect>> dialoguesWithEffects = BowlingLaneDialogueEffects.GetDialogueWithEffects();

        if (dialoguesWithEffects.ContainsKey(d.name))
        {
            DialogueEffect de = dialoguesWithEffects[d.name][choice];
            dateNPC.ChangeMoodLevel(de.moodChange);
            if(de.moodChange < 0)
            {
                MC.PauseMusic();
            }

            if(de.locationCommand != null)
            {
                CommandLocation(de.locationCommand);
            }
            if (de.commands != null)
            {
                DeceiverDialogueCommand(de.commands);
            }
        }

        if(dateNPC.moodLevel == -3)
        {
            //Serve final message and stop all other dialogue?
            dm.StartDialogue(attackDialogue);
            StartCoroutine("AttackPlayer");
        }
    }

    IEnumerator AttackPlayer()
    {
        yield return new WaitUntil(DialogueNotInPlay);
        yield return new WaitForSeconds(1);
        ActivateHorrorAttack();
    }

    bool DialogueNotInPlay()
    {
        return !dm.HasActiveDialogue();
    }

    private void DeceiverDialogueCommand(Dictionary<string, string> commands)
    {
        if (commands.ContainsKey("NextDialogueIndex"))
        {
            ChangeNextDialogue(Int32.Parse(commands["NextDialogueIndex"]));
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

    public void ActivateHorrorAttack()
    {
        dateNPCNav.AttackPlayer();
    }
}
