using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorController : GameManager
{

    void Start()
    {
        NPCPatrol();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NPCPatrol()
    {
        dateNPCNav.ReceiveCommand("Patrol");
    }
}
