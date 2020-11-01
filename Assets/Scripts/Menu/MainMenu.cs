using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public GameObject loopTrigger;
    public GameObject panelStartGame;
    public GameObject particles;
    public GameObject controller;
   
    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0)) {
            loopTrigger.SetActive(false);
            panelStartGame.SetActive(false);
            controller.SetActive(true);
            particles.SetActive(true);
        }
    }
}
