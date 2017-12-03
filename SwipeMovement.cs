using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwipeMovement : MonoBehaviour
{
    //public GameObject player;
    //public float minSwipeDistY;
    //public float minSwipeDistX;
    //private Vector2 startPos;

    //void Update()
    //{
    //    #if UNITY_ANDROID
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.touches[0];
    //        switch (touch.phase)
    //        {
    //            case TouchPhase.Began:
    //                startPos = touch.position;
    //                break;
    //            case TouchPhase.Ended:
    //                float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
    //                if (swipeDistVertical > minSwipeDistY)
    //                {
    //                    float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
    //                    if (swipeValue > 0)//up swipe
    //                        player.GetComponent<PlayerController>().MoveUp();//Jump ();
    //                    else if (swipeValue < 0)//down swipe
    //                        player.GetComponent<PlayerController>().MoveDown();//Shrink ();
    //                }

    //                float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
    //                if (swipeDistHorizontal > minSwipeDistX)
    //                {
    //                    float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
    //                    if (swipeValue > 0)//right swipe
    //                        player.GetComponent<PlayerController>().MoveRight();
    //                    else if (swipeValue < 0)//left swipe
    //                        player.GetComponent<PlayerController>().MoveLeft();//MoveLeft ();
    //                }
    //                break;
    //        }
    //    }
    //}

    public GameObject player;
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    private List<Vector3> touchPositions = new List<Vector3>(); //store all the touch positions in list

    void Start()
    {
        dragDistance = Screen.height * 20 / 100; //dragDistance is 20% height of the screen 
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)  //use loop to detect more than one swipe
        { //can be ommitted if you are using lists 
          /*if (touch.phase == TouchPhase.Began) //check for the first touch
          {
              fp = touch.position;
              lp = touch.position;

          }*/

            if (touch.phase == TouchPhase.Moved) //add the touches to list as the swipe is being made
            {
                touchPositions.Add(touch.position);
            }

            if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                //lp = touch.position;  //last touch position. Ommitted if you use list
                fp = touchPositions[0]; //get first touch position from the list of touches
                lp = touchPositions[touchPositions.Count - 1]; //last touch position 

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal 
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            player.GetComponent<PlayerController>().MoveRight();
                        }
                        else
                        {   //Left swipe
                            player.GetComponent<PlayerController>().MoveLeft();
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            player.GetComponent<PlayerController>().MoveUp();
                        }
                        else
                        {   //Down swipe
                            player.GetComponent<PlayerController>().MoveDown();
                        }
                    }
                }
            }
            else
            {   //It's a tap as the drag distance is less than 20% of the screen height

            }
        }
    }

}