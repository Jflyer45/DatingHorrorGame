using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LightSwitch : MonoBehaviour
{
    public TMP_Text indicator;
    bool canSwitch = false;
    public List<Light> connectedLights;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSwitch && Input.GetKeyDown(KeyCode.F))
        {
            foreach(Light light in connectedLights)
            {
                light.gameObject.SetActive(!light.gameObject.activeSelf);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.ToLower() == "player")
        {
            canSwitch = true;
            indicator.gameObject.SetActive(true);
            indicator.text = "Press 'F' to switch light";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.ToLower() == "player")
        {
            canSwitch = false;
            indicator.text = "";
            indicator.gameObject.SetActive(false);
        }
    }
}
