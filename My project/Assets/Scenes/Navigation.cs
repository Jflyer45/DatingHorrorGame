using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Navigation : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent nav;
    [SerializeField] GameObject player;
    [SerializeField] BowlingLaneRoutes blRoutes;
    [SerializeField] bool TESTATTACKPLAYER = false;

    private List<Transform> currentRoute = null;
    private int routeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TESTATTACKPLAYER)
        {
            nav.destination = player.transform.position;
        }
        else
        {
            Move();
        }
    }

    public void ReceiveCommand(string routeKey)
    {
        // Route may need to become an object so more data can be stored like if the npc needs to run/walk
        currentRoute = blRoutes.GetRoutes()[routeKey];
        routeIndex = 0;
    }

    private void Move()
    {
        // See if there is a route
        if (currentRoute != null)
        {
            // Check if not made it to desination (only checking x & y), else iterate to next location
            if(nav.transform.position.x != currentRoute[routeIndex].position.x &&
                nav.transform.position.y != currentRoute[routeIndex].position.y)
            {
                nav.destination = currentRoute[routeIndex].position;
            }
            else
            {
                // Check if at the last location
                if(routeIndex == currentRoute.Count - 1)
                {
                    routeIndex = 0;
                    currentRoute = null;
                }
                else
                {
                    routeIndex++;
                    nav.destination = currentRoute[routeIndex].position;
                }
            }
        }
    }

    void FacePlayer()
    {
        
    }
}
