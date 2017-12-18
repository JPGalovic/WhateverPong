using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeep : MonoBehaviour {
    public int score = 0;

	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Text>().text = "Score: " + score.ToString();
	}

    public void Add()
    {
        score++;
    }
}
