using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorBasementRoutes : Routes
{
    public List<Transform> Laundry;
    public List<Transform> BottomOfStairs;
    public override Dictionary<string, List<Transform>> GetRoutes()
    {
        Dictionary<string, List<Transform>> dic = new Dictionary<string, List<Transform>>();
        dic.Add("Laundry", Laundry);
        dic.Add("BottomOfStairs", BottomOfStairs);
        return dic;
    }
}
