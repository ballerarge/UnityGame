using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {

	[Header ("Set in Inspector")]
	public float rotationSpeed;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		anim.SetTrigger ("Idle");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			anim.SetTrigger ("Running");
		} else if (Input.GetKeyUp (KeyCode.W)) {
			anim.SetTrigger ("Idle");
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			anim.SetTrigger ("RunningBackwards");
		} else if (Input.GetKeyUp (KeyCode.S)) {
			anim.SetTrigger ("Idle");
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("JumpFinished", false);
			anim.SetTrigger ("Jump");
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (0, -rotationSpeed, 0);
			Camera.main.transform.Rotate (0, -rotationSpeed, 0);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (0, rotationSpeed, 0);
			Camera.main.transform.Rotate (0, rotationSpeed, 0);
		}

		if (anim.GetBool ("JumpFinished")) {
			if (Input.GetKey (KeyCode.W)) {
				anim.SetTrigger ("Running");
			} else if (Input.GetKey (KeyCode.S)) {
				anim.SetTrigger ("RunningBackwards");
			} else {
				anim.SetTrigger ("Idle");
			}
			anim.SetBool ("JumpFinished", false);
		}
	}
}
