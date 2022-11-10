using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public bool isLocked = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.ToLower() == "key")
        {
            isLocked = false;
            transform.eulerAngles = new Vector3(0, 92, 0);
        }
    }
}
