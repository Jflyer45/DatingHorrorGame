using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueAgent : MonoBehaviour
{
    // Needs to be abstracted to NPC so that the bartender has access to 
    public NPC self;
    private Navigation selfNav;
    public TMP_Text rangeIndicator;
    bool inRange = false;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        selfNav = GetComponentInParent<Navigation>();
        DisableUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.F) && !selfNav.IsMoving())
        {
            FacePlayer();
            gm.ServeDialogue(self.npcName);
            DisableUI();
        }
    }

    // Visual queue to player they can interact
    void EnableUI()
    {
        rangeIndicator.text = "Press 'f' to speak";
    }
    void DisableUI()
    {
        rangeIndicator.text = "";
    }

    private void FacePlayer()
    {
        self.transform.LookAt(gm.player.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO do not allow interaction if NPC is moving.
        if (other.tag == "Player")
        {
            EnableUI();
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            DisableUI();
            inRange = false;
        }
    }
}
