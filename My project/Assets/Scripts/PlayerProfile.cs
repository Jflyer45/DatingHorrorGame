using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile
{
    static PlayerProfile instance;
    public string playerName;
    public string favColor;
    public string getAway;

    public static void SetName(string name)
    {
        PlayerPrefs.SetString("name", name);
    }

    public static string GetName()
    {
        return PlayerPrefs.GetString("name");
    }

    public static void SetFavoriteColor(string fav)
    {
        PlayerPrefs.SetString("favoriteColor", fav);
    }

    public static string GetFavoriteColor()
    {
        return PlayerPrefs.GetString("favoriteColor");
    }

}
