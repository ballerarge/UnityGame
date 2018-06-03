using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[Header ("Set in Inspector")]
	public GameObject player;
	public float cameraDistance;

	void Start() {
	}

	void LateUpdate() {
		transform.position = player.transform.position - player.transform.forward * cameraDistance;
		transform.LookAt (player.transform.position);
	}
}
