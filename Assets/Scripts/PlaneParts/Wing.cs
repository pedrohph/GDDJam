using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<Obstacles>()) {
            collision.gameObject.GetComponent<Obstacles>().WingCollision();
        }
    }
}
