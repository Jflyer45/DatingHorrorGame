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

    private TypewriterEffect TWE;
    private Dialogue currentDialogue;
    private bool clickToProgress = false;
    private bool canDialogue = true;
    // Start is called before the first frame update
    void Start()
    {
        TWE = GetComponent<TypewriterEffect>();
        //TWE.Run("This is a test . . . . . .  asdasd . asd test", textBox);
        TurnOffUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && clickToProgress && !TWE.currentlyTyping)
        {
            if(currentDialogue.nextDialogue is null)
            {
                EndDialogue();
            }
            else
            {
                ChangeDialouge(currentDialogue.nextDialogue);
            }
        }else if (Input.GetKeyDown(KeyCode.Mouse0) && TWE.currentlyTyping)
        {
            Debug.Log("TRIED CLICKING TO SKIP");
            TWE.FinishEarly();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (canDialogue)
        {
            TurnOnUI();
            EnableCursor();
            DisablePlayerMovement();

            currentDialogue = dialogue;
            //this.textBox.text = currentDialogue.displayText;
            TWE.Run(currentDialogue.displayText, textBox);
            SetUpOptionButtons();
        }
    }

    public void EndDialogue()
    {
        Debug.Log("Ending Dialogue");
        TWE.FinishEarly();
        TurnOffUI();
        DisableCursor();
        EnablePlayerMovement();

        currentDialogue = null;
    }

    // Given a dialogue is already in play, use this to change to the next one
    public void ChangeDialouge(Dialogue dialogue)
    {
        gm.NotifyChangeDialogue();
        if (dialogue)
        {
            currentDialogue = dialogue;
            TWE.Run(currentDialogue.displayText, textBox);
            //this.textBox.text = currentDialogue.displayText;
            SetUpOptionButtons();

            // Should there be a pause in music, resume after the player continues
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
        // Make any unused buttons invisable
        while (index < optionButtons.Count)
        {
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

    public void DisableDialogue()
    {
        canDialogue = false;
    }

    public void EnableDialogues()
    {
        canDialogue = true;
    }
}
