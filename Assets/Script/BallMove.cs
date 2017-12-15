using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {
    float deltaX = -0.1f;
    float deltaY = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(deltaX, deltaY);
	}

    public void ReflectX()
    {
        deltaX = deltaX * -1.0f;
    }

    public void ReflectY()
    {
        deltaY = deltaY * -1.0f;
    }

    private void Score()
    {
        GameObject.Find("GameScore").SendMessage("Deduct");
        this.gameObject.transform.position = new Vector3(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Paddle")
            ReflectX();
        if (collision.gameObject.tag == "Barrier")
            ReflectY();
        if (collision.gameObject.tag == "Wall")
            ReflectX();
        if (collision.gameObject.tag == "Score")
            Score();
    }
}
