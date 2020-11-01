using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour {
    public delegate void WinTrigged();
    public event WinTrigged OnWinTriggered;

    public delegate void WinSFX(AudioClip clip);
    public event WinSFX OnSFXPlayed;

    public AudioClip clip;

    public void Start() {
        CameraFollow cm = Camera.main.GetComponent<CameraFollow>();
        cm.ListenWinTrigger(this);

        PlayerMovement pm = Camera.main.gameObject.transform.parent.GetComponentInChildren<PlayerMovement>();
        pm.ListenWinTrigger(this);

        Controller controller = GameObject.FindObjectOfType<Controller>();
        controller.ListenWinTrigger(this);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (OnWinTriggered != null) {
                OnWinTriggered();
            }
            if (OnSFXPlayed != null) {
                OnSFXPlayed(clip);
            }
        }
    }
}
