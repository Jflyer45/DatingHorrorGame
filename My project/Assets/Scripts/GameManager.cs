using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Navigation dateNPC;

    // Start is called before the first frame update
    void Start()
    {
        CommandLocation("LaneToBar");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CommandLocation(string routeKey)
    {
        dateNPC.ReceiveCommand(routeKey);
    }
}
