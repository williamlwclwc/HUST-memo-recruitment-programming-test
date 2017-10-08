using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart_button : MonoBehaviour {

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
         #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
         #else
         Application.Quit();
         #endif
    }
}
