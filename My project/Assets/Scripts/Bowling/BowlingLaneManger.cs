using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingLaneManger : MonoBehaviour
{
    public int score = 0;
    public Transform ballReturnPoint;
    public float targetTime = 10;
    public List<BowlingPin> pins;

    public bool ballInPlay;
    public float timer;
    void Start()
    {
        timer = targetTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (ballInPlay && timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else if(ballInPlay && timer <= 0){
            // Logic to reset
            score += PinsDown();
            ResetPins();

            timer = targetTime;
            ballInPlay = false;
        }
    }

    public void BallGuttered(GameObject ball)
    {
        Debug.Log("Ball Guttered!");
        float x = ballReturnPoint.transform.position.x;
        float y = ballReturnPoint.transform.position.y;
        float z = ballReturnPoint.transform.position.z;
        ball.transform.position = new Vector3(x, y, z);
    }

    // When ball enters the lane
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Lane Collision");
        if(other.tag == "Ball")
        {
            ballInPlay = true;
        }
    }

    private int PinsDown()
    {
        int total = 0;
        foreach(BowlingPin pin in pins)
        {
            if (pin.isKnockedOver)
            {
                total++;
            }
        }
        return total;
    }

    private void ResetPins()
    {
        foreach(BowlingPin pin in pins)
        {
            pin.ResetPin();
        }
    }
}
