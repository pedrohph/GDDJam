using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WoodPiece : Obstacles {
    public WoodPiece UpperWood;
    public WoodPiece LowerWood;

    public GameObject loot;

    public void RemoveJoint() {
        if (GetComponent<FixedJoint>())
            GetComponent<FixedJoint>().breakForce = 0;
    }

    public override void WingCollision() {
        PlaySound(AudioCut);
        gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 25, ForceMode.Impulse);
        // RemoveJoint();
        if (LowerWood != null) {
            LowerWood.RemoveJoint();
        }

        DisableColliders();
        Invoke("DieTree", 0.3f);
        StartCoroutine(SlowTimeAndShake());
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

    void DieTree()
    {
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
}
