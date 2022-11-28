using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    public string displayText;
    public string[] optionsText;
    public Dialogue[] optionDialogue;
    public Dialogue nextDialogue;

    public List<string> CommandKeyChoice0;
    public List<string> CommandValueChoice0;
    public List<string> CommandKeyChoice1;
    public List<string> CommandValueChoice1;
    public List<string> CommandKeyChoice2;
    public List<string> CommandValueChoice2;

    public List<string> CommandAlwaysKey;
    public List<string> CommandAlwaysValue;

    public List<string> CommandBeforeKey;
    public List<string> CommandBeforeValue;

    public Dialogue()
    {
        displayText = "";
        optionsText = new string[3];
        optionDialogue = new Dialogue[3];

        CommandKeyChoice0 = new List<string>();
        CommandValueChoice0 = new List<string>();
        CommandKeyChoice1 = new List<string>();
        CommandValueChoice1 = new List<string>();
        CommandKeyChoice2 = new List<string>();
        CommandValueChoice2 = new List<string>();

        CommandAlwaysKey = new List<string>();
        CommandAlwaysValue = new List<string>();

        CommandBeforeKey = new List<string>();
        CommandBeforeValue = new List<string>();
    }
}
