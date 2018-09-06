using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [Header("Set in Inspector")]
    public Transform player;
    public float cameraDistance;

    void LateUpdate()
    {
        transform.position = player.position - player.forward * cameraDistance;
        //transform.position = new Vector3 (transform.position.x, transform.position.y + 5, transform.position.z);
        transform.LookAt(player);
    }
}
