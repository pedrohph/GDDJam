using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenLog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(-2, 2), -4, Random.Range(-2, 2), ForceMode.Impulse);    
    }

    
}
