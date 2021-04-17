using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Saw : MonoBehaviour {
    public Vector3 rotateVelocity;
    // Start is called before the first frame update
    void Start() {
        transform.DOLocalRotate(rotateVelocity, 0.5f, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
    }
}
