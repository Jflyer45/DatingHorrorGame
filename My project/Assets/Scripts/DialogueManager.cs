using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject UIscreen;
    public TextMeshProUGUI textBox;
    public List<GameObject> optionButtons;
    private Dialogue currentDialogue;
    public Dialogue test;

    private bool clickToProgress = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue(test);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && clickToProgress)
        {
            if(currentDialogue.nextDialogue is null)
            {
                EndDialogue();
            }
            else
            {
                ChangeDialouge(currentDialogue.nextDialogue);
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        TurnOnUI();
        EnableCursor();

        currentDialogue = dialogue;
        this.textBox.text = currentDialogue.displayText;
        SetUpOptionButtons();
    }

    public void EndDialogue()
    {
        Debug.Log("Ending Dialogue");
        TurnOffUI();
        DisableCursor();
        currentDialogue = null;
    }

    // Given a dialogue is already in play, use this to change to the next one
    public void ChangeDialouge(Dialogue dialogue)
    {
        if (dialogue)
        {
            currentDialogue = dialogue;
            this.textBox.text = currentDialogue.displayText;
            SetUpOptionButtons();
        }
        else
        {
            EndDialogue();
        }
    }

    private void SetUpOptionButtons() 
    {
        if (currentDialogue.optionsText is null || currentDialogue.optionsText.Length == 0)
        {
            Debug.Log("Click to progess true");
            clickToProgress = true;
        }
        else
        {
            clickToProgress = false;
        }

        int index = 0;
        foreach (string optionText in currentDialogue.optionsText)
        {
            optionButtons[index].SetActive(true);
            optionButtons[index].GetComponentInChildren<Text>().text = optionText;
            index++;
        }
        Debug.Log("Index: " + index + " button count: " + optionButtons.Count);
        // Make any unused buttons invisable
        while (index < optionButtons.Count)
        {
            Debug.Log("Removing button");
            optionButtons[index].SetActive(false);
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
        ChangeDialouge(currentDialogue.optionDialogue[i]);
    }

    private void EnableCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void DisableCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
