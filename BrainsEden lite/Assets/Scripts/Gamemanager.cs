using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour {

    private ItemsControl itemctrl;
    public int score=0;

    // Use this for initialization
    void Start () {
        score = 0;
        itemctrl = GetComponent<ItemsControl>();
        itemctrl.Create_random_item();//create the first object
	}

	// Update is called once per frame
	void Update () {
		//if what the player do is correct,destory the item ,score++,create next object
        if(itemctrl.iscorrect)
        {
            score++;
            itemctrl.Create_random_item();
        }
        //wrong operation and the game is over
        if(itemctrl.gameover)
        {
            itemctrl.gameover = false;
            Application.LoadLevel("Gameover");//go to gameover scene
        }
    }
    //click restart button to reload main scene
    public void OnStartGame(string scenename)
    {
        Application.LoadLevel(scenename);
    }

}
