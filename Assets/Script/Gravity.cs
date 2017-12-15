using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    [Header("Acceleration Settings")]
    public float xAccel = 0.0f; // Force of gravity in x plain.
    public float yAccel = 0.0f; // Force of gravity in y plain.

    [Header("Terminal Velocity Settings")]
    public float xTerm = 0.0f; // Terminal Velocity in x plain.
    public float yTerm = 0.0f; // Terminal Velocity in y plain.

    [Header("Current Velocity")]
    [SerializeField]
    private float xVel;
    [SerializeField]
    private float yVel;

    // Use this for initialization
    void Start()
    {
        xVel = 0.0f;
        yVel = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (xAccel > 0.0f && xVel < xTerm)
            xVel += xAccel;
        else if (xAccel < 0.0f && xVel > xTerm)
            xVel += xAccel;

        if (yAccel > 0.0f && yVel < yTerm)
            yVel += yAccel;
        else if (yAccel < 0.0f && yVel > yTerm)
            yVel += yAccel;

        applyDelta();
    }

    public void applyDelta()
    {
        Vector3 newPos = new Vector3(this.gameObject.transform.position.x + xVel, this.gameObject.transform.position.y + yVel, this.gameObject.transform.position.z);
        this.gameObject.transform.position = newPos;
    }

    public float XVel { get { return xVel; } set { xVel = value; } }
    public float YVel { get { return yVel; } set { yVel = value; } }
}