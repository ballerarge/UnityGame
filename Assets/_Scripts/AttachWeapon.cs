using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachWeapon : MonoBehaviour {
	public GameObject weapon;

	// Use this for initialization
	void Start () {
		
		Transform rightMFinger = FindDeepChild (transform, "MiddleFinger1_R");
		print (rightMFinger.name);
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
