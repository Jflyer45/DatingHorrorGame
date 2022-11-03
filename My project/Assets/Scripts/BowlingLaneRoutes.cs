using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingLaneRoutes : Routes, IRoutes
{
    public List<Transform> LaneToSide;
    public List<Transform> SideToLane;
    public List<Transform> LaneToBar;
    public List<Transform> BarToLane;
    public List<Transform> Bar;
    public List<Transform> BowlingBall;

    public override Dictionary<string, List<Transform>> GetRoutes()
    {
        Dictionary<string, List<Transform>> dic = new Dictionary<string, List<Transform>>();
        dic.Add("LaneToSide", LaneToSide);
        dic.Add("SideToLane", SideToLane);
        dic.Add("LaneToBar", LaneToBar);
        dic.Add("BarToLane", BarToLane);
        dic.Add("Bar", Bar);
        dic.Add("BowlingBall", BowlingBall);
        return dic;
    }
}
