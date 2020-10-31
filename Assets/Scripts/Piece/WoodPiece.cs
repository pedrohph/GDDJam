using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPiece : Obstacles{
 
    public void RemoveJoint() {
        if (GetComponent<FixedJoint>())
            GetComponent<FixedJoint>().breakForce = 0;
    }

    public override void WingCollision() {
        PlaySound(AudioCut);
        RemoveJoint();
    }

    public override void BodyCollision() {
        PlaySound(AudioCollision);
        GameOver();
    }
}
