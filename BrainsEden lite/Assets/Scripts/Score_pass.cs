using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_pass : MonoBehaviour {

    public int current_score;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        current_score = GameObject.Find("GameManager").GetComponent<Gamemanager>().score;
    }
}
