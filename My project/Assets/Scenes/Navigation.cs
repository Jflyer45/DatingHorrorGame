using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Navigation : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent nav;
    private NPC self;
    [SerializeField] GameObject player;
    [SerializeField] Routes routes;
    [SerializeField] bool TESTATTACKPLAYER = false;
    [SerializeField] GameManager gm;

    private List<Transform> currentRoute = null;
    private int routeIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        self = GetComponent<NPC>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TESTATTACKPLAYER)
        {
            nav.destination = player.transform.position;
            self.ChangeAnimationToRunning();
        }
        else
        {
            Move();
        }
    }

    public void ReceiveCommand(string routeKey)
    {
        currentRoute = routes.GetRoutes()[routeKey];
        routeIndex = 0;
        self.ChangeAnimationToWalk(); // put this here so that it's only called once
        NotifyGM(); // We are now moving
    }

    private void Move()
    {
        // See if there is a route
        if (currentRoute != null)
        {
            // Check if not made it to desination (only checking x & y), else iterate to next location
            if (nav.transform.position.x != currentRoute[routeIndex].position.x &&
                nav.transform.position.y != currentRoute[routeIndex].position.y)
            {
                nav.destination = currentRoute[routeIndex].position;
            }
            else
            {
                // Check if at the last location
                if(routeIndex == currentRoute.Count - 1)
                {
                    self.ChangeAnimationToIdle();
                    routeIndex = 0;
                    currentRoute = null;
                    NotifyGM(); // no longer moving
                }
                else
                {
                    routeIndex++;
                    nav.destination = currentRoute[routeIndex].position;
                }
            }
        }
    }

    private void NotifyGM()
    {
        bool state;
        if(currentRoute == null){state = false;}else{state = true;}
        gm.UpdateAgentsMovementState(self.GetNPCName(), state);
    }

    public void AttackPlayer()
    {
        TESTATTACKPLAYER = true;
        nav.speed = 6;
        nav.acceleration = 100; //so player cannot juke
    }

    public void StopMoving()
    {
        currentRoute = null;
        nav.ResetPath();
        nav.speed = 0;
    }

    void FacePlayer()
    {
        self.transform.LookAt(player.transform);
    }
}
