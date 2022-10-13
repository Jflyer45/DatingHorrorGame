using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingLaneRoutes : MonoBehaviour, IRoutes
{
    public List<Transform> LaneToSide;
    public List<Transform> SideToLane;
    public List<Transform> LaneToBar;
    public List<Transform> BarToLane;

    public Dictionary<string, List<Transform>> GetRoutes()
    {
        Dictionary<string, List<Transform>> dic = new Dictionary<string, List<Transform>>();
        dic.Add("LaneToSide", LaneToSide);
        dic.Add("SideToLane", SideToLane);
        dic.Add("LaneToBar", LaneToBar);
        dic.Add("BarToLane", BarToLane);
        return dic;
    }
}
