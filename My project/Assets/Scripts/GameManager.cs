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
    private int bartenderDialogueIndex = 3;
    public GameObject player;
    public Dialogue attackDialogue;
    public MusicController MC;
    public GameObject bowlingBall;

    public bool jumpscareActive = false;
    protected bool dateNPCMoving = false;
    private bool lostRepour = false;
    private bool dialoguePast = false;

    // Start is called before the first frame update
    void Start()
    {
        StartBowling();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CommandLocation(string routeKey)
    {
        dateNPCNav.ReceiveCommand(routeKey);
    }

    private void CommandLocation(string routeKey, float leniency)
    {
        dateNPCNav.ReceiveCommand(routeKey, leniency);
    }

    private Dialogue NextDialogue(string agentName)
    {
        //temp code
        if (agentName == "erik")
        {
            return dialogues[dateNPCDialogueIndex];
        }
        else if (agentName == "jukebox")
        {
            return dialogues[2];
        }
        else if(agentName == "bartender")
        {
            return dialogues[bartenderDialogueIndex];
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

    private void ChangeBartenderDialogue(int index)
    {
        bartenderDialogueIndex = index;
    }
    
    public void ReceivePlayerChoice(int choice, Dialogue d)
    {
        // Builds command dic that is always run
        Dictionary<string, string> alwaysCommands = new Dictionary<string, string>();
        for(int i = 0; i < d.CommandAlwaysKey.Count; i++)
        {
            alwaysCommands.Add(d.CommandAlwaysKey[i], d.CommandAlwaysValue[i]);
        }

        // Builds command dic for only the choice made
        Dictionary<string, string> choiceCommands = new Dictionary<string, string>();
        if(choice == 0)
        {
            for (int i = 0; i < d.CommandKeyChoice0.Count; i++)
            {
                choiceCommands.Add(d.CommandKeyChoice0[i], d.CommandValueChoice0[i]);
            }
        }else if(choice == 1)
        {
            for (int i = 0; i < d.CommandKeyChoice1.Count; i++)
            {
                choiceCommands.Add(d.CommandKeyChoice1[i], d.CommandValueChoice1[i]);
            }
        }else
        {
            for (int i = 0; i < d.CommandKeyChoice2.Count; i++)
            {
                choiceCommands.Add(d.CommandKeyChoice2[i], d.CommandValueChoice2[i]);
            }
        }

        DeceiverDialogueCommand(alwaysCommands);
        DeceiverDialogueCommand(choiceCommands);

        if (dateNPC.moodLevel == -3)
        {
            //Serve final message and stop all other dialogue?
            dm.StartDialogue(attackDialogue);
            StartCoroutine("AttackPlayer");
        }
    }

    IEnumerator AttackPlayer()
    {
        MC.PlayHorrorAttack();
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
        if (commands.ContainsKey("Mood"))
        {
            dateNPC.ChangeMoodLevel(Int32.Parse(commands["Mood"]));
            MC.PauseMusic();
            lostRepour = true;
        }
        if (commands.ContainsKey("Location"))
        {
            CommandLocation(commands["Location"]);
        }
        if (commands.ContainsKey("NextDialogueIndex"))
        {
            ChangeNextDialogue(Int32.Parse(commands["NextDialogueIndex"]));
        }
        if (commands.ContainsKey("ChangeSong"))
        {
            MC.ChangeSong(Int32.Parse(commands["ChangeSong"]));
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

    // Used by dialogue manager to notify GM
    public void NotifyChangeDialogue()
    {
        // In the case the player cauzed music stop, it will resume after dialogue change
        if (!MC.IsPlaying() && dialoguePast)
        {
            Debug.Log("Resuming");
            MC.Resume();
            lostRepour = false;
            dialoguePast = false;
        }
        else if(lostRepour)
        {
            dialoguePast = true;
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
        jumpscareActive = true;
        dm.DisableDialogue();
    }

    public void StartBowling()
    {
        dateNPCNav.PickUpItem(bowlingBall);
        //while (dateNPCMoving)
        //{
            //yield return null;
        //}
        //dateNPC.transform.LookAt(bowlingBall.transform);

        //Debug.Log("PickUp now");
        // Coroutine till get to ball?
        //dateNPC.ChangeAnimationToPickUp();
        //On trigger enter appned to hand?
        //move to ally
        //dateNPC.ChangeAnimationToBowling();
        //shoot bowling ball.
    }
}
