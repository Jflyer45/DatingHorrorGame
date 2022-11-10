using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    public GameObject horrorNPC;
    public bool isOn = true;
    public float speedrate = 5;
    private AudioSource AS;
    private bool isPlaying;

    public float time;
    private float resetTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        time = resetTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            float distance = Vector3.Distance(this.transform.position, horrorNPC.transform.position);
            SetSpeedRate(distance);
            time -= (Time.deltaTime * speedrate);
            if (time <= 0)
            {
                AS.Play();
                time = resetTime;
            }
        }
        
    }

    IEnumerator PlaySound()
    {
        //We only put this logic in here to not waste CPU
        float distance = Vector3.Distance(this.transform.position, horrorNPC.transform.position);
        SetSpeedRate(distance);

        isPlaying = true;
        
        yield return new WaitForSeconds(speedrate);
        AS.Play();
        isPlaying = false;
    }

    private void SetSpeedRate(float distance)
    {
        if(distance >= 10)
        {
            speedrate = 1;
        }
        else if(distance >= 5 && distance < 10)
        {
            speedrate = 2.5f;
        }
        else if (distance >= 3 && distance < 5)
        {
            speedrate = 5f;
        } else if (distance < 3)
        {
            speedrate = 8f;
        }
    }
}
