using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPiece : MonoBehaviour {
    //Modificar esse script para fazer as que são feitas de ferro (utilizar herança)

    public void WingCollided() {
        RemoveJoint();
    }

    public void RemoveJoint() {
        if (GetComponent<FixedJoint>())
            GetComponent<FixedJoint>().breakForce = 0;
    }
}
