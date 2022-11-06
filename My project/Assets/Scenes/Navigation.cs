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
    private HorrorBasementBT bt;

    private List<Transform> currentRoute = null;
    private int routeIndex = 0;
    private float leniency = .1f;

    // Start is called before the first frame update
    void Awake()
    {
        bt = GetComponent<HorrorBasementBT>();
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

    public void ReceiveCommand(GameObject obj)
    {
        currentRoute = new List<Transform>() {obj.transform};
        routeIndex = 0;
        self.ChangeAnimationToWalk(); // put this here so that it's only called once
        NotifyGM(); // We are now moving
    }

    public void ReceiveCommand(string routeKey, float distanceLeniency)
    {
        leniency = distanceLeniency;
        ReceiveCommand(routeKey);
    }

    private void Move()
    {
        // See if there is a route
        if (currentRoute != null)
        {
            nav.destination = currentRoute[routeIndex].position;
            if(nav.remainingDistance <= leniency && nav.pathPending == false)
            {
                Debug.Log(routeIndex == currentRoute.Count - 1);
                // Check if at the last location
                if(routeIndex == currentRoute.Count -1)
                {
                    Debug.Log("Reached target" + currentRoute[routeIndex].position);
                    Debug.Log(nav.remainingDistance);
                    Debug.Log(currentRoute[0].name);
                    self.ChangeAnimationToIdle();
                    routeIndex = 0;
                    currentRoute = null;
                    NotifyGM(); // no longer moving
                    if(bt != null)
                    {
                        bt.NotifyBT();
                    }
                }
                else
                {
                    Debug.Log("New location");
                    Debug.Log(routeIndex);
                    routeIndex++;
                    nav.destination = currentRoute[routeIndex].position;
                }
            }
        }
    }

    private void NotifyGM()
    {
        gm.UpdateAgentsMovementState(self.GetNPCName(), IsMoving());
    }

    public bool IsMoving()
    {
        if (currentRoute == null) { return false; } else { return true; }
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

    private IEnumerator PickUpItemCo(GameObject item)
    {
        ReceiveCommand(item);
        while (IsMoving())
        {
            yield return null;
        }
        //dateNPC.transform.LookAt(bowlingBall.transform);

        Debug.Log("PickUp now");
        self.ChangeAnimationToPickUp();
        while (self.GetAnimator().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !self.GetAnimator().IsInTransition(0))
        {
            yield return null;
        }
        //On trigger enter appned to hand?
        //move to ally
        self.ChangeAnimationToBowling();
        //shoot bowling ball.
    }

    public void PickUpItem(GameObject item)
    {
        StartCoroutine(PickUpItemCo(item));
    }
}
