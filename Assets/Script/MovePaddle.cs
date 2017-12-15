using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovePaddle : MonoBehaviour {
    public UnityEvent onUp;
    public UnityEvent onDown;

	// Use this for initialization
	void Start () {
		
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
        this.gameObject.transform.position += new Vector3(0, n);
    }
}
