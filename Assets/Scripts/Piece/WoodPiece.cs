﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPiece : Obstacles {
    public WoodPiece UpperWood;
    public WoodPiece LowerWood;

    public void RemoveJoint() {
        if (GetComponent<FixedJoint>())
            GetComponent<FixedJoint>().breakForce = 0;
    }

    public override void WingCollision() {
        PlaySound(AudioCut);
        gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 10, ForceMode.Impulse);
        // RemoveJoint();
        if (LowerWood != null) {
            LowerWood.RemoveJoint();
        }

        DisableColliders();
    }

    public override void BodyCollision() {
        PlaySound(AudioCollision);
        GameOver();
    }

    public void DisableColliders() {
        gameObject.GetComponent<Collider>().enabled = false;

        if (transform.GetComponentInChildren<MetalPiece>()){
            transform.GetComponentInChildren<MetalPiece>().DisableColliders();
        }

        if (UpperWood != null) {
            UpperWood.DisableColliders();
        }
    }
}
