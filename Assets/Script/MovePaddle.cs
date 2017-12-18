using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovePaddle : MonoBehaviour {
    public UnityEvent onUp;
    public UnityEvent onDown;

    public float
        clampMarginMinX = 0.0f,
        clampMarginMaxX = 0.0f,
        clampMarginMinY = 0.0f,
        clampMarginMaxY = 0.0f;

    private float
        clampMinX,
        clampMaxX,
        clampMinY,
        clampMaxY;

    // Use this for initialization
    void Start()
    {
        clampMinX = Camera.main.ScreenToWorldPoint(new Vector2(0 + clampMarginMinX, 0)).x;
        clampMaxX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - clampMarginMaxX, 0)).x;
        clampMinY = Camera.main.ScreenToWorldPoint(new Vector2(0, 0 + clampMarginMinY)).y;
        clampMaxY = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height + clampMarginMaxY)).y;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey("up"))
            onUp.Invoke();

        if (Input.GetKey("down"))
            onDown.Invoke();
    }

    public void Move(float n)
    {
        Vector3 position = transform.position;
        transform.position += new Vector3(0, n);
        if (transform.position.y <= clampMinY || transform.position.y >= clampMaxY)
            transform.position = position; //step back
    }
}
