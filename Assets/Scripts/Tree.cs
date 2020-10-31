using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
    public GameObject woodPiece;
    public float woodlenght;
    public int lenght;
    // Start is called before the first frame update
    void Start() {
        CreateTree();
    }

    // Update is called once per frame
    void Update() {

    }

    public void CreateTree() {
        Vector3 newPiecePos = transform.position;
        GameObject lastCreated = null;
        GameObject g;
        for (int i = 0; i < lenght; i++) {
            newPiecePos.y += woodlenght;
            g = Instantiate(woodPiece, newPiecePos, transform.rotation, transform);
            if (i != 0) {
                lastCreated.GetComponent<FixedJoint>().connectedBody = g.GetComponent<Rigidbody>();
            }
            if(i == lenght - 1) {
                g.GetComponent<FixedJoint>().breakForce = 0;
            }
            lastCreated = g;
        }
    }
}
