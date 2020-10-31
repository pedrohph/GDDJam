using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public PlayerMovement player;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Swipe();
    }

    public void Swipe() {
        if (Input.GetMouseButtonDown(0)) {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButton(0)) {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            /*
            //swipe upwards
            if (currentSwipe.y > 0 ) {
                Debug.Log("up swipe");
            }
            //swipe down
            if (currentSwipe.y < 0) {
                Debug.Log("down swipe");
            }
            //swipe left
            if (currentSwipe.x < 0 ) {
                Debug.Log("left swipe");
            }
            //swipe right
            if (currentSwipe.x > 0) {
                Debug.Log("right swipe");
            }*/


            Debug.Log(currentSwipe);
            player.MovePlayer(currentSwipe.x, currentSwipe.y);
        }
    }

}
