﻿using System.Collections;
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

    void Update() {
        if (!Application.isPlaying) {
            transform.localPosition = offset;
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

}
