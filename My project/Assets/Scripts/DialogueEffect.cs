using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEffect 
{
    public int moodChange = 0;
    public string locationCommand = null;

    public DialogueEffect(int moodChange, string locationCommand)
    {
        this.moodChange = moodChange;
        this.locationCommand = locationCommand;
    }
}
