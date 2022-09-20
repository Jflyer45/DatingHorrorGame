using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject UIscreen;
    public TextMeshProUGUI textBox;
    public List<UnityEngine.UI.Button> optionButtons;
    private Dialogue currentDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        TurnOnUI();
        currentDialogue = dialogue;
        this.textBox.text = dialogue.displayText;

        int index = 0;
        foreach(string optionText in currentDialogue.optionsText)
        {
            optionButtons[index].GetComponentInChildren<Text>().text = optionText;
            index++;
        }
        // Make any unused buttons invisable
        while (index < optionButtons.Count - 1)
        {
            optionButtons[index].enabled = false;
            index++;
        }
    }
    private void TurnOnUI()
    {
        UIscreen.SetActive(true);
    }
    private void TurnOffUI()
    {
        UIscreen.SetActive(false);
    }

    public void MakeChoice(int i)
    {

    }
}
