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
    public FPSController playerController;
    public GameManager gm;

    private Dialogue currentDialogue;
    private bool clickToProgress = false;
    // Start is called before the first frame update
    void Start()
    {
        TurnOffUI();
        
    }

    // Update is called once per frame
    void Update()
    {
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
        DisablePlayerMovement();

        currentDialogue = dialogue;
        this.textBox.text = currentDialogue.displayText;
        SetUpOptionButtons();
    }

    public void EndDialogue()
    {
        Debug.Log("Ending Dialogue");
        TurnOffUI();
        DisableCursor();
        EnablePlayerMovement();

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
        optionButtons[0].SetActive(false);
        optionButtons[1].SetActive(false);
        optionButtons[2].SetActive(false);
        textBox.text = "";
    }

    public void MakeChoice(int i)
    {
        // Notify GM
        gm.ReceivePlayerChoice(i, currentDialogue);

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

    private void EnablePlayerMovement()
    {
        playerController.canMove = true;
    }

    private void DisablePlayerMovement()
    {
        playerController.canMove = false;
    }

    public bool HasActiveDialogue()
    {
        if(currentDialogue != null) { return true; } else { return false; }
    }
}
