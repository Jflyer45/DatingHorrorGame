using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateNPC : MonoBehaviour, INPC
{
    private int moodLevel;
    private Animator animator;

    public string name;
    public bool test = false;
    public bool test2 = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (test)
        {
            ChangeAnimationToWalk();
        }
        else if (test2)
        {
            ChangeAnimationToRunning();
        }
        //else
        //{
           // ChangeAnimationToIdle();
       // }
    }

    public void ChangeAnimationToWalk()
    {
        Debug.Log("Changing to walkling");
        ResetAnimatorBools();
        animator.SetBool("isWalking", true);
    }
    public void ChangeAnimationToIdle()
    {
        ResetAnimatorBools();
    }

    public void ChangeAnimationToRunning()
    {
        ResetAnimatorBools();
        animator.SetBool("isRunning", true);
    }

    public void ResetAnimatorBools()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
    }

    public int GetMoodLevel()
    {
        return moodLevel;
    }
    public void ChangeMoodLevel(int amount)
    {
        int newLevel = moodLevel - amount;
        if (newLevel >= 4 || newLevel <= -4)
        {
            moodLevel = 0;
        }
        else
        {
            moodLevel = newLevel;
        }
    }

    // Getters Setters
    public string GetName()
    {
        return name;
    }
}
