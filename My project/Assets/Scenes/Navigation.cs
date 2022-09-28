using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Navigation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] NavMeshAgent nav;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.destination = player.transform.position;
    }
}
