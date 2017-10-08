using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adapt_Screen : MonoBehaviour {

    public Camera mainCamera;

    // Use this for initialization
    void Start ()        
    {
        mainCamera = Camera.main;
        //  mainCamera.aspect --->  摄像机的长宽比（宽度除以高度）
        mainCamera.aspect = 1.5f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
