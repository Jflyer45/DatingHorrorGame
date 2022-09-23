using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateNPC : MonoBehaviour
{
    private int moodLevel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetMoodLevel()
    {
        return moodLevel;
    }
    public void ChangeMoodLevel(int newLevel)
    {
        if (newLevel >= 4 || newLevel <= -4)
        {
            moodLevel = 0;
        }
        else
        {
            moodLevel = newLevel;
        }
    }
}
