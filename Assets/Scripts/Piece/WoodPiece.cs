using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WoodPiece : Obstacles {
   
    public GameObject loot;
    public GameObject woodParticle;

    public override bool WingCollision() {
        PlaySound(AudioCut);
        gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 25, ForceMode.Impulse);
        // RemoveJoint();
        if (LowerPiece != null) {
            LowerPiece.RemoveJoint();
        }
        Instantiate(woodParticle, transform.position, transform.rotation);
        DisableColliders();
        DieTree();
        StartCoroutine(SlowTimeAndShake());
        return false;
    }

    public override void BodyCollision() {
        Shake();
        PlaySound(AudioCollision);
        GameOver();
    }

    void DieTree() {
        Instantiate(loot, transform.parent.GetChild(1).position, Quaternion.identity);
        Destroy(transform.parent.gameObject, 10);
    }

    public IEnumerator SlowTimeAndShake() {
        Camera.main.DOKill();
        Time.timeScale = 0.2f;
        Camera.main.DOShakePosition(0.1f, 1f, 10);
        yield return new WaitForSecondsRealtime(0.2f);
        Time.timeScale = 1;
    }

    public void Shake() {
        Camera.main.DOKill();
        Camera.main.DOShakePosition(0.5f, 2f, 10);
    }
}
