﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
    public GameObject treeTop;
    // Start is called before the first frame update
    void Start() {
        CreateTree();
    }

    // Update is called once per frame
    void Update() {

    }

    public void CreateTree() {
        for(int i = 1; i< transform.childCount; i++) {
            if(i != 1) {
                if (i != transform.childCount - 1) {
                    transform.GetChild(i).gameObject.GetComponent<WoodPiece>().UpperWood = transform.GetChild(i + 1).gameObject.GetComponent<WoodPiece>();
                }
                if ( i != 2) {
                    transform.GetChild(i).gameObject.GetComponent<WoodPiece>().LowerWood = transform.GetChild(i - 1).gameObject.GetComponent<WoodPiece>();
                }
            }
            if (i != transform.childCount - 1) {

                transform.GetChild(i).gameObject.GetComponent<FixedJoint>().connectedBody = transform.GetChild(i + 1).gameObject.GetComponent<Rigidbody>();
            } else {
                treeTop.transform.localPosition = transform.GetChild(i).localPosition;
                treeTop.transform.localPosition += new Vector3(0,1,0);
                transform.GetChild(i).gameObject.GetComponent<FixedJoint>().connectedBody = transform.GetChild(0).GetComponent<Rigidbody>();
            }
        }
        
    }
}
