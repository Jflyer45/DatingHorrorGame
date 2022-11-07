using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PickUp : MonoBehaviour
{
    public float throwForce = 600;
    Vector3 objectPos;
    float distance;
    Rigidbody itemRigidbody;

    public bool canHold = true;
    private GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;
    public TMP_Text crosshair;
    public bool wasThrown;

    private void Start()
    {
        item = gameObject;
        itemRigidbody = item.GetComponent<Rigidbody>();
        tempParent = GameObject.Find("Guide");
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
                StartCoroutine("WasThrown");
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

    IEnumerator WasThrown()
    {
        wasThrown = true;
        yield return new WaitForSeconds(1);
        wasThrown = false;
    }

    private void CrossHairGlow(bool mode)
    {
        if(crosshair != null)
        {
            if (mode)
            {
                crosshair.color = Color.yellow;
            }
            else
            {
                crosshair.color = Color.white;
            }
        }
    }

    void OnMouseDown()
    {
        if (distance <= 1f)
        {
            CrossHairGlow(true);
            isHolding = true;
            itemRigidbody.useGravity = false;
            itemRigidbody.detectCollisions = true;
        }
    }

    void OnMouseUp()
    {
        CrossHairGlow(false);
        isHolding = false;
    }
}

