﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public PlayerMovement player;
    bool pressed = false;

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
            firstPressPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            pressed = true;
        }
        if (pressed && Input.GetMouseButton(0)) {
            //save ended touch 2d point
            secondPressPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //create vector from the two points

            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();

            if (player != null)
                player.MovePlayer(currentSwipe.x, currentSwipe.y);
        }
    }

    public void GameOver() {
        this.enabled = false;
    }

    public void ListenWinTrigger(WinTrigger wt) {
        wt.OnWinTriggered += GameOver;
    }

}
