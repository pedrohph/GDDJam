using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicListener : MonoBehaviour {
   
    // Start is called before the first frame update
    void Start() {
        DontDestroyOnLoad(gameObject);
        if(FindObjectsOfType<MusicListener>().Length > 1) {
            Destroy(gameObject);
        }
    }

}
