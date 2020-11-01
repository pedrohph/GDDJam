using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTree : MonoBehaviour {
    public Transform playerShip;
    public GameObject panelMenu;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (playerShip != null) {
            if (!panelMenu.activeSelf && transform.position.z <= playerShip.position.z) {
                transform.position += new Vector3(0, 0, 160);
            }
        }
    }
}
