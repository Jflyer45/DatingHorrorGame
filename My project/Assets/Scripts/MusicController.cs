using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource AS;
    public AudioClip horrorClip;
    public List<AudioClip> songs;
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

    public void ChangeSong(int i)
    {
        AS.clip = songs[i];
        AS.Play();
    }

    public void PlayHorrorAttack()
    {
        AS.clip = horrorClip;
        AS.Play();
    }

    public bool IsPlaying()
    {
        return AS.isPlaying;
    }
}
