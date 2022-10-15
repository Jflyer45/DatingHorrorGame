using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    // Start is called before the first frame update
    private Navigation npcNav;
    private AudioSource AS;
    [SerializeField] private GameManager GM;
    [SerializeField] private FPSController fps;

    private void Awake()
    {
        npcNav = GetComponent<Navigation>();
        AS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(GM.jumpscareActive);
        if (GM.jumpscareActive && other.tag == "Player")
        {
            AS.Play();
            fps.canMove = false;
            npcNav.StopMoving();
        }
    }
}
