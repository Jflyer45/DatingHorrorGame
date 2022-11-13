using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorBasementRoutes : Routes
{
    public List<Transform> Laundry;
    public List<Transform> BottomOfStairs;
    public List<Transform> Patrol;
    public List<Transform> CloseRightCorner;
    public List<Transform> CloseLeftCorner;
    public List<Transform> FarRightCorner;
    public List<Transform> FarLeftCorner;

    public List<Transform> Bathroom;
    public List<Transform> TableRoom;
    public List<Transform> TVRoom;
    public List<Transform> BedRoom;
    public List<Transform> SpawnRoom;
    public List<Transform> ExitDoor;

    public override Dictionary<string, List<Transform>> GetRoutes()
    {
        Dictionary<string, List<Transform>> dic = new Dictionary<string, List<Transform>>();
        dic.Add("Laundry", Laundry);
        dic.Add("BottomOfStairs", BottomOfStairs);
        dic.Add("Patrol", Patrol);
        dic.Add("CloseRightCorner", CloseRightCorner);
        dic.Add("CloseLeftCorner", CloseLeftCorner);
        dic.Add("FarRightCorner", FarRightCorner);
        dic.Add("FarLeftCorner", FarLeftCorner);

        dic.Add("Bathroom", Bathroom);
        dic.Add("TableRoom", TableRoom);
        dic.Add("TVRoom", TVRoom);
        dic.Add("BedRoom", BedRoom);
        dic.Add("SpawnRoom", SpawnRoom);
        dic.Add("ExitDoor", ExitDoor);
        return dic;
    }
}
