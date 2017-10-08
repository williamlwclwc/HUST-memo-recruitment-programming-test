using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    private bool is_correct;
    private float obj_time=20;//the player has to act in obj_time seconds
    public Slider cd_strip;
    private int current_score;
    private int level_up1 = 0, level_up2 = 0, level_up3 = 0;

	// Use this for initialization
	void Start () {
        //initialize time strip
        cd_strip.value = cd_strip.maxValue;
    }
	
	// Update is called once per frame
	void Update () {
        obj_time -= Time.deltaTime;//time reduction
        cd_strip.value = obj_time;//update time strip
        is_correct = GameObject.Find("GameManager").GetComponent<ItemsControl>().iscorrect;
        current_score = GameObject.Find("GameManager").GetComponent<Gamemanager>().score;
        //if the player do the right thing
        if (is_correct)
        {
            Destroy(gameObject);
        }
        //if overtime, game over
        if(obj_time<=0)
        {
            Destroy(gameObject);
            Application.LoadLevel("Gameover");
        }
        //increase the difficulty of the game
        if(level_up1==0 && current_score>=20)
        {
            obj_time = 10;
            level_up1 = 1;
        }
        if (level_up2==0 && current_score>=55)
        {
            obj_time = 5;
            level_up2 = 1;
        }
        if(level_up3==0&& current_score>=80)
        {
            obj_time = 2;
            level_up3 = 1;
        }
    }
}
