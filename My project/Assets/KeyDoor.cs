using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public bool isLocked = true;
    public AudioClip doorCreak;
    public AudioClip lockedShutter;

    private AudioSource AS;

    void Start()
    {
        AS = GetComponent<AudioSource>();
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
            AS.clip = doorCreak;
            AS.Play();
        }
        if(other.tag.ToLower() == "fakekey")
        {
            AS.clip = lockedShutter;
            AS.Play();
            // indicator 
        }
    }
}
