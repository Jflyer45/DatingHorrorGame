using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JukeBox : MonoBehaviour
{
    public TMP_Text rangeIndicator;
    bool inRange = false;
    private bool isEnabled = false;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void EnableJukebox()
    {
        isEnabled = true;
    }

    public void DisableJukebox()
    {
        isEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled && inRange && Input.GetKeyDown(KeyCode.F))
        {
            gm.ServeDialogue("jukebox");
            DisableUI();
        }
    }

    void EnableUI()
    {
        rangeIndicator.text = "Press 'f' to choose song.";
    }
    void DisableUI()
    {
        rangeIndicator.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO do not allow interaction if NPC is moving.
        if (isEnabled && other.tag == "Player")
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
