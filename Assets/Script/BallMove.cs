using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {
    public float deltaX = -0.1f;
    public float deltaY = 0.1f;

    public float speed = 1.0f;
    public float deltaDifficulty = 1.0f;

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
	void Start () {
        clampMinX = Camera.main.ScreenToWorldPoint(new Vector2(0 + clampMarginMinX, 0)).x;
        clampMaxX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - clampMarginMaxX, 0)).x;
        clampMinY = Camera.main.ScreenToWorldPoint(new Vector2(0, 0 + clampMarginMinY)).y;
        clampMaxY = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height + clampMarginMaxY)).y;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        transform.position += new Vector3(deltaX * speed, deltaY * speed);

        if (transform.position.x <= clampMinX)
            ScoreRight();

        if (transform.position.x >= clampMaxX)
            ScoreLeft();

        if (transform.position.y <= clampMinY || transform.position.y >= clampMaxY)
        {
            ReflectY();
            transform.position = position; // Step back;
        }
	}

    public void ReflectX()
    {
        deltaX = deltaX * -1.0f;
        IncreaseDifficulty();
    }

    public void ReflectY()
    {
        deltaY = deltaY * -1.0f;
        IncreaseDifficulty();
    }

    public void IncreaseDifficulty()
    {
        speed = speed * deltaDifficulty;
    }

    private void ScoreLeft()
    {
        GameObject.Find("GameScoreLeft").SendMessage("Add");
        this.gameObject.transform.position = new Vector3(0, 0);
        speed = 1.0f;
    }

    private void ScoreRight()
    {
        GameObject.Find("GameScoreRight").SendMessage("Add");
        this.gameObject.transform.position = new Vector3(0, 0);
        speed = 1.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Paddle")
            ReflectX();
    }
}
