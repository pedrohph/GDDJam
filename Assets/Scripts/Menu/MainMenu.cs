using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public GameObject loopTrigger;
    public GameObject panelStartGame;
    public GameObject particles;
    public GameObject controller;
    public GameObject[] trail = new GameObject[2];

    private void Start() {
        if(PlayerPrefs.GetInt("win", 0) == 1) {
            Active();
        }

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0)) {
            Active();  
        }
    }

    public void Active() {
        PlayerPrefs.SetInt("win", 0);
        loopTrigger.SetActive(false);
        panelStartGame.SetActive(false);
        controller.SetActive(true);
        particles.SetActive(true);
        trail[0].SetActive(true);
        trail[1].SetActive(true);
    }
}
