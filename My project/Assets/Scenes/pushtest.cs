using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushtest : MonoBehaviour
{
    private Rigidbody rb;
    private bool coolDown = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(5, 0, 50)); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!coolDown)
        {
            StartCoroutine(WiggleTick());
        }
    }

    private void ApplySmallWiggle()
    {
        
        rb.AddForce(new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5)));
    }

    IEnumerator WiggleTick()
    {
        coolDown = true;
        ApplySmallWiggle();
        yield return new WaitForSeconds(3);
        coolDown = false;
    }
}
