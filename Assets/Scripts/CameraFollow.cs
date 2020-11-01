using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [Header("Target")]
    public Transform target;

    [Space]

    [Header("Offset")]
    public Vector3 offset = Vector3.zero;

    [Space]

    [Header("Limits")]
    public Vector2 limits = new Vector2(5, 3);

    [Space]

    [Header("Smooth Damp Time")]
    [Range(0, 1)]
    public float smoothTime;

    private Vector3 velocity = Vector3.zero;

    public bool stopCameraMovement;

    private void Awake() {
     //   Invoke("StopCamera", 2);
    }

    void Update() {
        if (!Application.isPlaying) {
            transform.localPosition = offset;
        }

        if (stopCameraMovement) {
            if (offset.z > -25) {
                offset -= new Vector3(0, -5*Time.deltaTime, gameObject.transform.parent.GetComponent<FrontMovement>().speedMovement * Time.deltaTime);
            } else {
                gameObject.transform.parent.GetComponent<FrontMovement>().speedMovement = 0;
            }
        }

        FollowTarget(target);
    }

    void LateUpdate() {
        Vector3 localPos = transform.localPosition;
        transform.localPosition = new Vector3(Mathf.Clamp(localPos.x, -limits.x, limits.x), Mathf.Clamp(localPos.y, -limits.y, limits.y), localPos.z);
    }

    public void FollowTarget(Transform t) {
        if (t != null) {
            Vector3 localPos = transform.localPosition;
            Vector3 targetLocalPos = t.transform.localPosition;
            transform.localPosition = Vector3.SmoothDamp(localPos, new Vector3(targetLocalPos.x + offset.x, targetLocalPos.y + offset.y, targetLocalPos.z + offset.z), ref velocity, smoothTime);
        }
    }

    public void StopCamera() {
        Invoke("RealStopCamera", 1);
        
    }

    public void RealStopCamera() {
        stopCameraMovement = true;
    }

    public void ListenWinTrigger(WinTrigger wt) {
        wt.OnWinTriggered += StopCamera;
    }
}
