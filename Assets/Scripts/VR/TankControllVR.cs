using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllVR : MonoBehaviour {

	public float rightForce;

	void FixedUpdate(){
		float a = (transform.rotation.x * 100f);
		rightForce = (a / 45f);
	}

}