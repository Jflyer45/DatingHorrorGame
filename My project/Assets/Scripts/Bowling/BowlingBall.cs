using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    private AudioSource AS;
    private PickUp pickUpController;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        pickUpController = GetComponent<PickUp>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && pickUpController.wasThrown)
        {
            AS.Play();
        }
    }
}
