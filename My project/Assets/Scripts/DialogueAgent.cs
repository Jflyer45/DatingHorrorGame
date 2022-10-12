using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAgent : MonoBehaviour
{
    // Needs to be abstracted to NPC so that the bartender has access to this
    public DateNPC self;
    bool inRange = false;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.F))
        {
            gm.ServeDialogue(self.name);

        }
    }

    // Visual queue to player they can interact
    void EnableUI()
    {
        
    }
    void DisableUI()
    {

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
