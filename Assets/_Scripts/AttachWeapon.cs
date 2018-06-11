using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachWeapon : MonoBehaviour {
	public GameObject weapon;
	private Transform finger;

	// Use this for initialization
	void Start () {
		finger = FindDeepChild (transform, "MiddleFinger1_R");
	}

	void LateUpdate() {
		weapon.transform.position = finger.position;
//		weapon.transform.rotation = finger.rotation;
	}

	public Transform FindDeepChild(Transform aParent, string aName) {
		var result = aParent.Find (aName);
		if (result != null) {
			return result;
		}

		foreach (Transform child in aParent) {
			result = FindDeepChild (child, aName);
			if (result != null) {
				return result;
			}
		}
		return null;
	}
}
