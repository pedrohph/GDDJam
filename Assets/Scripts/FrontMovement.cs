using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontMovement : MonoBehaviour
{
    public float speedMovement;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speedMovement * Time.deltaTime);
    }
}
