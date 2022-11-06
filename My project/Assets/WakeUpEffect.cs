using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpEffect : MonoBehaviour
{
    Animator a;
    void Start()
    {
        a = GetComponent<Animator>();
        //StartCoroutine("WakeUp");
    }

    private IEnumerator WakeUp()
    {
        yield return new WaitForSeconds(1);
        a.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        a.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        a.enabled = false;

    }
}
