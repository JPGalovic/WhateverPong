using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCollision : MonoBehaviour {

    public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision");
        if(col.gameObject.tag == "Ball")
        {
            Debug.Log("Collision");
            col.gameObject.SendMessage("Reflect");
        }
    }
}
