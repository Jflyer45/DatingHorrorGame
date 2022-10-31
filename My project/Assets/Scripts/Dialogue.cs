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
}
