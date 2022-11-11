using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyDoor : MonoBehaviour
{
    public bool isLocked = true;
    public AudioClip doorCreak;
    public AudioClip lockedShutter;
    public TMP_Text indicator;
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
            indicator.gameObject.SetActive(true);
            indicator.text = "Wrong key...";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.ToLower() == "fakekey")
        {
            indicator.gameObject.SetActive(false);
            indicator.text = "";
        }
    }
}
