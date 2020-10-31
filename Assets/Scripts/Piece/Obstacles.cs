using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacles : MonoBehaviour {

    public delegate void PlaySFX(AudioClip clip);
    public event PlaySFX PlayedSFX;

    public delegate void DefineGameOver();
    public event DefineGameOver DefinedGameOver;

    public AudioClip AudioCut;
    public AudioClip AudioCollision;

    protected void OnEnable() {
        AudioManager am = FindObjectOfType<AudioManager>();
        am.ListenSoundsFromObstacles(this);

        GameManager gm = FindObjectOfType<GameManager>();
        gm.ListenGameOver(this);
    }

    public void GameOver() {
        if (DefinedGameOver != null) {
            DefinedGameOver();
        }
    }

    public void PlaySound(AudioClip clip) {
        if (PlayedSFX != null) {
            PlayedSFX(clip);
        }
    }

    public abstract void WingCollision();
    public abstract void BodyCollision();
}
