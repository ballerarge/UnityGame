﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTransform;
    
    private Vector3 _cameraOffset;

    public bool LookAtPlayer = false;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool RotateAroundPlayer = false;

    public float RotationsSpeed = 5.0f;

    public float cameraDistance = 1.0f;

    // Use this for initialization
    void Start () {
        _cameraOffset = (transform.position - PlayerTransform.position) * cameraDistance;
    }

    // Update is called once per frame
    void LateUpdate() {

        if (RotateAroundPlayer) {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);

            _cameraOffset = camTurnAngle * _cameraOffset;
        }

        Vector3 newPos = PlayerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtPlayer || RotateAroundPlayer) {
            transform.LookAt(PlayerTransform);
        }
    }
}
