using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankVRLeftLever : MonoBehaviour {

	public float leftForce;

	void FixedUpdate(){
		float a = (transform.rotation.x * 100f);
		leftForce = (a / 45);
	}

}