using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacles : MonoBehaviour {
    public Obstacles UpperPiece;
    public Obstacles LowerPiece;

    public delegate void DefineGameOver();
    public event DefineGameOver DefinedGameOver;

    public AudioClip AudioCut;
    public AudioClip AudioCollision;

    protected void OnEnable() {
        GameManager gm = FindObjectOfType<GameManager>();
        gm.ListenGameOver(this);
    }

    public void GameOver() {
        if (DefinedGameOver != null) {
            DefinedGameOver();
        }
    }

    public void PlaySound(AudioClip clip) {
        AudioManager.Instance.PlaySFX(clip);    
    }

    public abstract bool WingCollision();
    public abstract void BodyCollision();

    public void DisableColliders() {
        if (gameObject.GetComponent<Collider>().enabled) {
            gameObject.GetComponent<Collider>().enabled = false;


            if (UpperPiece != null) {
                UpperPiece.DisableColliders();
            }

            if (LowerPiece != null) {
                LowerPiece.DisableColliders();
            }
        }
    }

    public void RemoveJoint() {
        if (GetComponent<FixedJoint>())
            GetComponent<FixedJoint>().breakForce = 0;
    }
}
