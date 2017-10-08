using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final_score : MonoBehaviour {

    private int score_text;
    Text your_score;

    // Use this for initialization
    void Start () {
        your_score = GameObject.Find("Canvas/score").GetComponent<Text>();
        score_text = GameObject.Find("ScoreManager").GetComponent<Score_pass>().current_score;
        your_score.text = "Your score: " + score_text.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
