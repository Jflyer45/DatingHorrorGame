using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    private Vector3 originalPosition;
    public float knockedOverAngle = 45f;
    public bool isKnockedOver; 

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = gameObject.transform.position;
        isKnockedOver = IsKnockedOver();
    }

    // Update is called once per frame
    void Update()
    {
        isKnockedOver = IsKnockedOver();
    }

    public void ResetPin()
    {
        gameObject.transform.position = originalPosition;
    }

    public bool IsKnockedOver()
    {
        float x = WrapAngle(gameObject.transform.eulerAngles.x);
        float y = WrapAngle(gameObject.transform.eulerAngles.y);
        float z = WrapAngle(gameObject.transform.eulerAngles.z);

        // Not knocked over if each value is between .45 and -.45
        return (x >= knockedOverAngle || x <= -knockedOverAngle
            || y >= knockedOverAngle || y <= -knockedOverAngle
            || z >= knockedOverAngle || z <= -knockedOverAngle);
    }

    //Used because unity's rotation in the editor is different which is stupid.
    private static float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }
}
