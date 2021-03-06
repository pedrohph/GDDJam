﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("Movimentacao")]
    public float movementSpeed;
    public float leanLimit;
    public float lerpTime;

    public Vector2 movementLimits;

    [Header("Visao")]
    public float lookSpeed;
    //public Transform aimTarget;

    public bool forcedPosition = false;

    public GameManager gm;

    public GameObject madeirinhas;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        PlayerMove(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // RotationLook(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
         HorizontalLean(transform, Input.GetAxis("Horizontal"));

        if (forcedPosition) {
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(0, -3, 0), movementSpeed * Time.deltaTime);
        }
    }

    public void MovePlayer(float x, float y) {
        PlayerMove(x, y);
        //RotationLook(x, y);
        HorizontalLean(transform, x);
    }

    public void PlayerMove(float x, float y) {
        transform.localPosition += new Vector3(x, y, 0) * movementSpeed * Time.deltaTime;
        ClampPosition();
    }

    void ClampPosition() {
        transform.localPosition = new Vector3(Mathf.Clamp(transform.position.x, -movementLimits.x, movementLimits.x), Mathf.Clamp(transform.position.y, -movementLimits.y, movementLimits.y), 0);// Camera.main.ViewportToWorldPoint(pos);
    }

    //public void RotationLook(float h, float v) {
    //    //aimTarget.parent.position = Vector3.zero;
    //    aimTarget.localPosition = new Vector3(h, v, 1);
    //    //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * movementSpeed);
    //}

    void HorizontalLean(Transform target, float axis) {
        Vector3 targetEulerAngels = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z, -axis * leanLimit, lerpTime));
    }

    public void ForcePosition() {
        forcedPosition = true;
        InvokeRepeating("DropLoot", 0.1f, 0.1f);
    }

    public void DropLoot() {
        if (gameObject.transform.localPosition == new Vector3(0, -3, 0) && Camera.main.GetComponent<CameraFollow>().offset.z < -25) {
            if (gm.lootCount > 0) {
                Instantiate(madeirinhas, gameObject.transform.position, gameObject.transform.rotation);
                // Instantiate(madeirinhas, gameObject.transform.position, gameObject.transform.rotation);
                gm.lootCount--;
            } else {
                CancelInvoke("DropLoot");
                //Gerar Painel de Game Win
            }
        }
    }

    public void ListenWinTrigger(WinTrigger wt) {
        wt.OnWinTriggered += ForcePosition;
    }
}
