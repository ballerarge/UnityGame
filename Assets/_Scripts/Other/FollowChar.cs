using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChar : MonoBehaviour {

    public Transform character;
	
	void Update () {
        transform.position = character.position + new Vector3(0, 4, 0);
	}
}
