using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorController : GameManager
{
    private bool isPatrol = true;

    void Start()
    {
        NPCPatrol();
    }

    // Update is called once per frame
    void Update()
    {
        //if(isPatrol && !dateNPCMoving)
        //{
            //NPCPatrol();
        //}
    }

    public void NPCPatrol()
    {
        Debug.Log("Patrol");
        dateNPCNav.ReceiveCommand("Patrol");
    }
}
