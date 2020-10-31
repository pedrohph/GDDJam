using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPiece : Obstacles{
    public WoodPiece UpperWood;
    public WoodPiece LowerWood;

    public void RemoveJoint() {
        gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 10, ForceMode.Impulse);
        if (GetComponent<FixedJoint>())
            GetComponent<FixedJoint>().breakForce = 0;
    }

    public override void WingCollision() {
        PlaySound(AudioCut);
        RemoveJoint();
        LowerWood.RemoveJoint();
    }

    public override void BodyCollision() {
        PlaySound(AudioCollision);
        GameOver();
    }
}
