using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource AS;
    public AudioClip horrorClip;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void PauseMusic()
    {
        AS.Pause();
    }

    public void Resume()
    {
        AS.Play();
    }

    public void PlayHorrorAttack()
    {
        AS.clip = horrorClip;
        AS.Play();
    }
}
