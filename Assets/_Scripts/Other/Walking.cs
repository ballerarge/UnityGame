using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {

	[Header ("Set in Inspector")]
	public float rotationSpeed;
    public Transform characterFollow;
    public float maxRot;
    public float rotFollowSpeed;
    public Vector3 jump;
    public float jumpForce;
    public float jumpTimer = 0.0f;
    public float maxJumpSeconds;
    public float fallTimer = 0.0f;
    public float maxFallSeconds;
    
    public bool jumping;
    public bool falling;
    Rigidbody rb;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		anim.SetTrigger ("Idle");
		rb = transform.parent.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            checkRotation();
        }

        // Animator code that fires events for
        // character running.
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

        // Jumping code. If character is not in process of jumping or falling,
        // space can be pressed to initiate jump.
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!jumping && !falling) {
				jumping = true;
				rb.useGravity = false;
				rb.AddForce(jump * jumpForce, ForceMode.Impulse);
			}
        }

        // If jumping, timer counts up to max time
        // before character should begin to fall.
        if (jumping) {
        	jumpTimer += Time.deltaTime;
        	float seconds = jumpTimer % 60;
        	if (seconds >= maxJumpSeconds) {
        		rb.useGravity = true;
        		jumping = false;
        		falling = true;
        		jumpTimer = 0;
        	}
        }

        // If falling, timer counts up to max time
        // before character is allowed to jump again.
        if (falling) {
        	fallTimer += Time.deltaTime;
        	float seconds = fallTimer % 60;
			if (seconds >= maxFallSeconds) {
        		falling = false;
        		fallTimer = 0;
        	}
        }

        // Rotation code for movement. Rotates character
        // and the object that the camera follows.
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (0, -rotationSpeed, 0);
            characterFollow.Rotate(0, -rotationSpeed, 0);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (0, rotationSpeed, 0);
            characterFollow.Rotate(0, rotationSpeed, 0);
        }
	}

    void checkRotation()
    {
        if ((Mathf.Abs(characterFollow.localEulerAngles.y) - Mathf.Abs(transform.localEulerAngles.y) > maxRot)
            || (Mathf.Abs(characterFollow.localEulerAngles.y) - Mathf.Abs(transform.localEulerAngles.y) < -maxRot))
        {
            characterFollow.rotation = Quaternion.RotateTowards(characterFollow.rotation, transform.rotation, rotFollowSpeed * Time.deltaTime);

        }
    }
}
