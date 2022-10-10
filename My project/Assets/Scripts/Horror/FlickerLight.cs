using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private Light lightOB;
    private AudioSource lightSound;

    public float minTime;
    public float maxTime;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
        lightOB = GetComponent<Light>();
        lightSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        LightsFlickering();
    }

    void LightsFlickering()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            lightOB.enabled = !lightOB.enabled;
            timer = Random.Range(minTime, maxTime);
            if (lightSound)
            {
                lightSound.Play();
            }
        }
    }
}
