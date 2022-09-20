using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    public string displayText;
    public string[] optionsText;
    public Dialogue[] optionDialogue;
    public Dialogue nextDialogue;
}
