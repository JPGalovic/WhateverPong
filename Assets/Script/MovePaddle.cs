using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovePaddle : MonoBehaviour {
    public float
        axisSpeed = 0.5f;

    public string
        axis;

    public float
        clampMarginMinY = 0.0f,
        clampMarginMaxY = 0.0f;

    private float
        clampMinY,
        clampMaxY;

    // Use this for initialization
    void Start()
    {
        clampMinY = Camera.main.ScreenToWorldPoint(new Vector2(0, 0 + clampMarginMinY)).y;
        clampMaxY = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height + clampMarginMaxY)).y;
    }

    // Update is called once per frame
    void Update () {
        Move(Input.GetAxis(axis) * axisSpeed);
    }

    public void Move(float n)
    {
        Vector3 position = transform.position;
        transform.position += new Vector3(0, n);
        if (transform.position.y <= clampMinY || transform.position.y >= clampMaxY)
            transform.position = position; //step back
    }
}
