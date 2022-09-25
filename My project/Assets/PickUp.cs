using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    float throwForce = 600;
    Vector3 objectPos;
    float distance;
    Rigidbody itemRigidbody;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;

    private void Start()
    {
        itemRigidbody = item.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);

        if (distance >= 1f)
        {
            isHolding = false;
        }

        if (isHolding)
        {
            itemRigidbody.velocity = Vector3.zero;
            itemRigidbody.angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if (Input.GetMouseButtonDown(1))
            {
                itemRigidbody.AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }


        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            itemRigidbody.useGravity = true;
            item.transform.position = objectPos;
        }
    }

    void OnMouseDown()
    {
        if (distance <= 1f)
        {
            isHolding = true;
            itemRigidbody.useGravity = false;
            itemRigidbody.detectCollisions = true;
        }
    }

    void OnMouseUp()
    {
        isHolding = false;
    }
}

