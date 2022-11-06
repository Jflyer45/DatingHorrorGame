using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpEffect : MonoBehaviour
{
    Animator a;
    void Start()
    {
        a = GetComponent<Animator>();
        StartCoroutine("test");
    }

    private IEnumerator test()
    {
        yield return new WaitForSeconds(3f);
        a.enabled = false;
    }
}
