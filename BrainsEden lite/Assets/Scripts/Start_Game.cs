using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStartGame(string scenename)
    {
        Application.LoadLevel(scenename);
    }

    public void Quit()
    {
    Application.Quit(); 
    }
}
