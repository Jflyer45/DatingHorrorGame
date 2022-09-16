using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TinderProfile
{
    public string name;
    public Sprite profilePicture;
    public string bio;
    public int scene;

    public TinderProfile(string name, string filepath, string bio, int scene)
    {
        this.name = name;
        this.profilePicture = LoadImage(filepath);
        this.bio = bio;
        this.scene = scene;
    }
    private Sprite LoadImage(string filename)
    {
        Debug.Log("Loaded image" + filename);
        //string filename = "Assets/Resources/Heightmaps/filename.png";
        //var rawData = System.IO.File.ReadAllBytes(filename);
        //Texture2D tex = new Texture2D(2, 2); // Create an empty Texture; size doesn't matter (she said)
        //tex.LoadImage(rawData);
        var sp = Resources.Load<Sprite>(filename);
        return sp;
    }
}


