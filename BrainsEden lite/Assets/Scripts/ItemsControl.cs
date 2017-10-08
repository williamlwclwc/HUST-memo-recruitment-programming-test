using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsControl : MonoBehaviour {

    public GameObject[] ItemsArray;
    private List<Vector2> positionlist = new List<Vector2>();
    private int current_rail;
    private string current_obj;
    private bool left_correct = false;
    private bool right_correct = false;
    public bool iscorrect = false;
    public bool gameover = false;
    public float minSwipeDistY;
    public float minSwipeDistX;
    private Vector2 startPos;
    private int dimension=0;
    private string swipe = "";
    public Camera mainCamera;

    // Use this for initialization
    void Start () {
        //set up the positions of the items
        positionlist.Clear();
        positionlist.Add(new Vector2(0, 200));
        positionlist.Add(new Vector2(0, 100));
        positionlist.Add(new Vector2(0, -100));
        positionlist.Add(new Vector2(0, -200));
    }
	
	// Update is called once per frame
	void Update () {
        iscorrect = false;
        Correctly_Slide(current_rail, current_obj);//check whether the player do the right move
	}
    //method of creating a new item in random position
    public void Create_random_item()
    {
        //reset the condition
        left_correct = false;
        right_correct = false;
        //obtain random position
        Vector2 pos = RandomPosition();
        //put up an item
        GameObject item = RandomPrefab(ItemsArray);
        Instantiate(item, pos, Quaternion.identity);
    }

    private Vector2 RandomPosition()
    {
        //obtain random position
        int positionindex = Random.Range(0, positionlist.Count);
        current_rail = positionindex + 1;//get the current obj's rail
        Vector2 pos = positionlist[positionindex];
        return pos;
    }

    private GameObject RandomPrefab(GameObject[] prefabs)
    {
        //put up random items
        int index = Random.Range(0, prefabs.Length);
        switch(index)//get the current obj's category
        {
            case 0:
                current_obj = "Cube";
                break;
            case 1:
                current_obj = "Sphere";
                break;
            case 2:
                current_obj = "Bomb";
                break;
        }
        return prefabs[index];
    }

    //check the operation whether it is correct or not
    private void Correctly_Slide(int rail,string obj)
    {
        int swipe_action = Swipe_detect();//get the player's swipe move
        swipe = "";//reset the swipe condition
        /*核心玩法的电脑端实现和滑动状态的return值
          轨道1的左侧左划，用按下Q键代替，1
          轨道1的左侧右划，用按下A键代替，2
          轨道2的左侧左划，用按下W键代替, 5
          轨道2的左侧右划，用按下S键代替, 6
          轨道3的左侧左划，用按下E键代替, 9
          轨道3的左侧右划，用按下D键代替, 10
          轨道4的左侧左划，用按下R键代替，13
          轨道4的左侧右划，用按下F键代替，14
          轨道1的右侧左划，用按下U键代替，3
          轨道1的右侧右划，用按下H键代替，4
          轨道2的右侧左划，用按下I键代替，7
          轨道2的右侧右划，用按下J键代替, 8
          轨道3的右侧左划，用按下O键代替, 11
          轨道3的右侧右划，用按下K键代替，12
          轨道4的右侧左划，用按下P键代替，15
          轨道4的右侧右划，用按下L键代替，16*/
        //检查玩家操作是否正确，轨道左侧右侧均正确iscorrect设置为true，有错误操作触发gameover
        switch(obj)
        {
            case "Cube":
                    switch (rail)
                    {
                    case 1://轨道1方块，轨道1左侧左划，右侧左划
                        if (Input.GetKeyDown(KeyCode.Q)||swipe_action==1)
                        {
                            dimension = 0;                        
                            left_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.U)||swipe_action==3)
                        {
                            dimension = 0;
                            right_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.H)||swipe_action==2||swipe_action==4)
                        {
                            gameover = true;
                        }
                        if(left_correct&&right_correct)
                        {
                            iscorrect = true;
                        }
                        break;
                    case 2://轨道2方块，轨道2左侧左划，右侧左划
                        if (Input.GetKeyDown(KeyCode.W)||swipe_action==5)
                        {
                            dimension = 0;
                            left_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.I)||swipe_action==7)
                        {
                            dimension = 0;
                            right_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.J)||swipe_action==6||swipe_action==8)
                        {
                            gameover = true;
                        }
                        if (left_correct && right_correct)
                        {
                            iscorrect = true;
                        }
                        break;
                    case 3://轨道3方块，轨道3左侧左划，右侧左划
                        if (Input.GetKeyDown(KeyCode.E)||swipe_action==9)
                        {
                            dimension = 0;
                            left_correct = true;
                        }
                        if(Input.GetKeyDown(KeyCode.O)||swipe_action==11)
                        {
                            dimension = 0;
                            right_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.K)||swipe_action==10||swipe_action==12)
                        {
                            gameover = true;
                        }
                        if (left_correct && right_correct)
                        {
                            iscorrect = true;
                        }
                        break;
                    case 4://轨道4方块，轨道4左侧左划，右侧左划
                        if (Input.GetKeyDown(KeyCode.R)||swipe_action==13)
                        {
                            dimension = 0;
                            left_correct = true;
                        }
                        if(Input.GetKeyDown(KeyCode.P)||swipe_action==15)
                        {
                            dimension = 0;
                            right_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.L)||swipe_action==14||swipe_action==16)
                        {
                            gameover = true;
                        }
                        if (left_correct && right_correct)
                        {
                            iscorrect = true;
                        }
                        break;
                    }
                    break;
            case "Sphere":
                switch (rail)
                {
                    case 1://轨道1球体，轨道1左侧右划，右侧右划
                        if (Input.GetKeyDown(KeyCode.A)||swipe_action==2)
                        {
                            dimension = 0;
                            left_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.H)||swipe_action==4)
                        {
                            dimension = 0;
                            right_correct = true;
                        }                        
                        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.U)||swipe_action==1||swipe_action==3)
                        {
                            gameover = true;
                        }
                        if (left_correct && right_correct)
                        {
                            iscorrect = true;
                        }
                        break;
                    case 2://轨道2球体，轨道2左侧右划，右侧右划
                        if (Input.GetKeyDown(KeyCode.S)||swipe_action==6)
                        {
                            dimension = 0;
                            left_correct = true;
                        }
                        if(Input.GetKeyDown(KeyCode.J)||swipe_action==8)
                        {
                            dimension = 0;
                            right_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.I)||swipe_action==5||swipe_action==7)
                        {
                            gameover = true;
                        }
                        if (left_correct && right_correct)
                        {
                            iscorrect = true;
                        }
                        break;
                    case 3://轨道3球体，轨道3左侧右划，右侧右划
                        if (Input.GetKeyDown(KeyCode.D)||swipe_action==10)
                        {
                            dimension = 0;
                            left_correct = true;
                        }
                        if(Input.GetKeyDown(KeyCode.K)||swipe_action==12)
                        {
                            dimension = 0;
                            right_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.O)||swipe_action==9||swipe_action==11)
                        {
                            gameover = true;
                        }
                        if (left_correct && right_correct)
                        {
                            iscorrect = true;
                        }
                        break;
                    case 4://轨道4球体，轨道4左侧右划，右侧右划
                        if (Input.GetKeyDown(KeyCode.F)||swipe_action==14)
                        {
                            dimension = 0;
                            left_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.L)||swipe_action==16)
                        {
                            dimension = 0;
                            right_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.P)||swipe_action==13||swipe_action==15)
                        {
                            gameover = true;
                        }
                        if (left_correct && right_correct)
                        {
                            iscorrect = true;
                        }
                        break;
                }
                break;
            case "Bomb":
                switch (rail)
                {
                    case 1://轨道1炸弹，轨道1左侧左划，右侧右划
                        if (Input.GetKeyDown(KeyCode.Q)||swipe_action==1)
                        {
                            dimension = 0;
                            left_correct = true;
                        }
                        if(Input.GetKeyDown(KeyCode.H)||swipe_action==4)
                        {
                            dimension = 0;
                            right_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.U)||swipe_action==2||swipe_action==3)
                        {
                            gameover = true;
                        }
                        if (left_correct && right_correct)
                        {
                            iscorrect = true;
                        }
                        break;
                    case 2://轨道2炸弹，轨道2左侧左划，右侧右划
                        if (Input.GetKeyDown(KeyCode.W)||swipe_action==5)
                        {
                            dimension = 0;
                            left_correct = true;
                        }
                        if(Input.GetKeyDown(KeyCode.J)||swipe_action==8)
                        {
                            dimension = 0;
                            right_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.I)||swipe_action==6||swipe_action==7)
                        {
                            gameover = true;
                        }
                        if (left_correct && right_correct)
                        {
                            iscorrect = true;
                        }
                        break;
                    case 3://轨道3炸弹，轨道3左侧左划，右侧右划
                        if (Input.GetKeyDown(KeyCode.E)||swipe_action==9)
                        {
                            dimension = 0;
                            left_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.K)||swipe_action==12)
                        {
                            dimension = 0;
                            right_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.O)||swipe_action==10||swipe_action==11)
                        {
                            gameover = true;
                        }
                        if (left_correct && right_correct)
                        {
                            iscorrect = true;
                        }
                        break;
                    case 4://轨道4炸弹，轨道4左侧左划，右侧右划
                        if (Input.GetKeyDown(KeyCode.R)||swipe_action==13)
                        {
                            dimension = 0;
                            left_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.L)||swipe_action==16)
                        {
                            dimension = 0;
                            right_correct = true;
                        }
                        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.P)||swipe_action==14||swipe_action==15)
                        {
                            gameover = true;
                        }
                        if (left_correct && right_correct)
                        {
                            iscorrect = true;
                        }
                        break;
                }
                break;
        }
    }
    //检测触屏滑动事件
    private int Swipe_detect()
    {
        if (Input.touchCount > 0)//used touch screen?
        {
            Touch touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began://the finger touched the screen
                    startPos = touch.position;//store the start position
                    if(startPos.x < 1010 && startPos.y > 800)
                    {
                        dimension = 1;//轨道1左侧
                    }else if(startPos.x > 1010 && startPos.y > 800)
                    {
                        dimension = 2;//轨道1右侧
                    }else if(startPos.x < 1010 && startPos.y > 640 && startPos.y < 800)
                    {
                        dimension = 3;//轨道2左侧
                    }else if(startPos.x > 1010 && startPos.y > 640 && startPos.y < 800)
                    {
                        dimension = 4;//轨道2右侧
                    }else if(startPos.x < 1010 && startPos.y > 200 && startPos.y < 360)
                    {
                        dimension = 5;//轨道3左侧
                    }else if(startPos.x > 1010 && startPos.y > 200 && startPos.y < 360)
                    {
                        dimension = 6;//轨道3右侧
                    }else if(startPos.x < 1010 && startPos.y < 200)
                    {
                        dimension = 7;//轨道4左侧
                    }else if(startPos.x > 1010 && startPos.y < 200)
                    {
                        dimension = 8;//轨道4右侧
                    }
                    break;
                case TouchPhase.Ended://the finger left the screen
                    //judge right/left swipe using x coordinates
                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                    if (swipeDistHorizontal > minSwipeDistX)
                    {
                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                        if (swipeValue > 0)//right swipe
                        {
                            swipe = "right";
                        }
                        else if (swipeValue < 0)//left swipe
                        {
                            swipe = "left";
                        }
                    }
                    break;
            }
        }
        switch(swipe)
        {
            case "left":
                switch(dimension)
                {
                    case 1:
                        return 1;//检测到轨道1左侧左划，Q
                    case 2:
                        return 3;//检测到轨道1右侧左划，U
                    case 3:
                        return 5;//检测到轨道2左侧左划，W
                    case 4:
                        return 7;//检测到轨道2右侧左划，I
                    case 5:
                        return 9;//检测到轨道3左侧左划，E
                    case 6:
                        return 11;//检测到轨道3右侧左划，O
                    case 7:
                        return 13;//检测到轨道4左侧左划，R
                    case 8:
                        return 15;//检测到轨道4右侧左划，P
                    default:
                        return 0;//非轨道的左划
                }
            case "right":
                switch(dimension)
                {
                    case 1:
                        return 2;//检测到轨道1左侧右划，A
                    case 2:
                        return 4;//检测到轨道1右侧右划，H
                    case 3:
                        return 6;//检测到轨道2左侧右划，S
                    case 4:
                        return 8;//检测到轨道2右侧右划，J
                    case 5:
                        return 10;//检测到轨道3左侧右划，D
                    case 6:
                        return 12;//检测到轨道3右侧右划，K
                    case 7:
                        return 14;//检测到轨道4左侧右划，F
                    case 8:
                        return 16;//检测到轨道4右侧右划，L
                    default:
                        return 0;//非轨道右划
                }
            default:
                return 0;//没有左划或右划
        }
    }
}
