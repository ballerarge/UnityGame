using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {

	[Header ("Set in Inspector")]
	public float rotationSpeed;
    public Transform characterFollow;
    public float maxRot;
    public float rotFollowSpeed;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		anim.SetTrigger ("Idle");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            checkRotation();
        }

        if (Input.GetKeyDown (KeyCode.W)) {
			anim.SetTrigger ("Running");
            checkRotation();
        } else if (Input.GetKeyUp (KeyCode.W)) {
			anim.SetTrigger ("Idle");
        }

		if (Input.GetKeyDown (KeyCode.S)) {
			anim.SetTrigger ("RunningBackwards");
            checkRotation();
        } else if (Input.GetKeyUp (KeyCode.S)) {
			anim.SetTrigger ("Idle");
        }

		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("JumpFinished", false);
			anim.SetTrigger ("Jump");
        }

		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (0, -rotationSpeed, 0);
            characterFollow.Rotate(0, -rotationSpeed, 0);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (0, rotationSpeed, 0);
            characterFollow.Rotate(0, rotationSpeed, 0);
        }

		if (anim.GetBool ("JumpFinished")) {
			if (Input.GetKey (KeyCode.W)) {
                anim.SetTrigger ("Running");
                checkRotation();
            } else if (Input.GetKey (KeyCode.S)) {
                anim.SetTrigger ("RunningBackwards");
                checkRotation();
            } else {
				anim.SetTrigger ("Idle");
			}
			anim.SetBool ("JumpFinished", false);
		}
	}

    void checkRotation()
    {
        if ((Mathf.Abs(characterFollow.localEulerAngles.y) - Mathf.Abs(transform.localEulerAngles.y) > maxRot)
            || (Mathf.Abs(characterFollow.localEulerAngles.y) - Mathf.Abs(transform.localEulerAngles.y) < -maxRot))
        {
            // characterFollow.rotation = Quaternion.Lerp(characterFollow.rotation, transform.rotation, 0.5f);
            characterFollow.rotation = Quaternion.RotateTowards(characterFollow.rotation, transform.rotation, rotFollowSpeed * Time.deltaTime);

        }
    }
}
