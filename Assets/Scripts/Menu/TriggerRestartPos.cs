using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRestartPos : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerMovement>()) {
            other.gameObject.transform.parent.position = new Vector3(0, 0, -30);
        }
    }
}
