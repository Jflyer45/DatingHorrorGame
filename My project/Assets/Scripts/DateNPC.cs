using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateNPC : NPC
{
    public int moodLevel;
    private UMAMoodSlider moodSlider;
    
    public bool test = false;
    public bool test2 = false;
    
    private void Awake()
    {
        SetAnimator(GetComponent<Animator>());
        moodSlider = GetComponent<UMAMoodSlider>();
    }

    public int GetMoodLevel()
    {
        return moodLevel;
    }
    public void ChangeMoodLevel(int amount)
    {
        int newLevel = moodLevel + amount;
        if (newLevel >= 4)
        {
            moodLevel = 3;
        }
        else if (newLevel <= -4)
        {
            moodLevel = -3;
        }
        else
        {
            moodLevel = newLevel;
        }

        SetFacialExpression();
    }

    private void SetFacialExpression()
    {
        moodSlider.mood = moodLevel;
    }
}
