using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Navigation : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent nav;
    [SerializeField] GameObject player;
    [SerializeField] List<Transform> locations;

    [SerializeField] bool test = false;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //nav.destination = player.transform.position;
        if (test)
        {
            FacePlayer();
        }
        else
        {
            nav.destination = locations[1].position;
        }
    }

    void FacePlayer()
    {
        nav.destination = player.transform.position;
    }
}
