using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_text : MonoBehaviour {

    private int score_text;
    Text your_score;

	// Use this for initialization
	void Start () {		
        your_score = GameObject.Find("Canvas/score").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        score_text = GameObject.Find("GameManager").GetComponent<Gamemanager>().score;
        your_score.text = "Your score: " + score_text.ToString();
	}
}
