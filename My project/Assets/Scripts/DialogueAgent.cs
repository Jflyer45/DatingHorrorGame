using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAgent : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Visual queue to player they can interact
    void EnableUI()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Entered Talking distance");
        }
    }
}
