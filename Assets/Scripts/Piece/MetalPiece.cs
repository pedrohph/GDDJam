using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalPiece : Obstacles {
    public override void WingCollision() {
        PlaySound(AudioCut);
        GameOver();
    }

    public override void BodyCollision() {
        PlaySound(AudioCollision);
        GameOver();
    }

    public void DisableColliders() {
        gameObject.GetComponent<Collider>().enabled = false;

    }
}
