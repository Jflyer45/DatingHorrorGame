using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushtest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(5, 0, 30)); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
