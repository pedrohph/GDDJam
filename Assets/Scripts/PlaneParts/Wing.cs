﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {
        if (GetComponent<WoodPiece>()) {
            collision.gameObject.GetComponent<WoodPiece>().wingCollided();
        }
    }
}
