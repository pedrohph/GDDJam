using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Saw : MonoBehaviour {
    public float rotateVelocity;
    // Start is called before the first frame update
    void Start() {
        transform.DOLocalRotate(new Vector3(0, 0, rotateVelocity), 0.5f, RotateMode.FastBeyond360).SetLoops(-1);
    }
}
