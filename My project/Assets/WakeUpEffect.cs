using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpEffect : MonoBehaviour
{
    Animator a;
    FPSController controller;
    void Start()
    {
        a = GetComponent<Animator>();
        //StartCoroutine("WakeUp");
    }
}
