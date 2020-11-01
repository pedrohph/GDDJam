using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MetalPiece : Obstacles {
    public override void WingCollision() {
        PlaySound(AudioCollision);
        Shake();
        GameOver();
    }

    public override void BodyCollision() {
        PlaySound(AudioCollision);
        Shake();
        GameOver();
    }

    public void DisableColliders() {
        gameObject.GetComponent<Collider>().enabled = false;

    }

    public void Shake() {
        Camera.main.DOKill();
        Camera.main.DOShakePosition(0.5f, 2f, 10);
    }
}
