using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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


    // Gets and Sets
    public string GetNPCName()
    {
        return npcName;
    }
    public void SetNPCName(string s)
    {
        this.npcName = s;
    }

    public Animator GetAnimator()
    {
        return animator;
    }
    public void SetAnimator(Animator a)
    {
        this.animator = a;
    }

}
