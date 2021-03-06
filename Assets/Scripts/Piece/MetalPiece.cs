﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalPiece : Obstacles {


    public override bool WingCollision() {
        PlaySound(AudioCollision);
        Shake();
        GameOver();
        return true;
    }

    public override void BodyCollision() {
        PlaySound(AudioCollision);
        Shake();
        GameOver();
    }

    public void Shake() {
        Camera.main.DOKill();
        Camera.main.DOShakePosition(0.5f, 2f, 10);
    }

}
