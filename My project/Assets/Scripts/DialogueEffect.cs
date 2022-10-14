using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEffect 
{
    public int moodChange = 0;
    public string locationCommand = null;
    public Dictionary<string, string> commands;

    public DialogueEffect(int moodChange, string locationCommand)
    {
        this.moodChange = moodChange;
        this.locationCommand = locationCommand;
    }
    public DialogueEffect(int moodChange, string locationCommand, Dictionary<string, string> commands)
    {
        this.moodChange = moodChange;
        this.locationCommand = locationCommand;
        this.commands = commands;
    }
}
