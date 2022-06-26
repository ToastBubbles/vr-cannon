using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTurretBarrelUpDown : MonoBehaviour {

	public float upDown;

	void FixedUpdate(){
		float a = (transform.rotation.x * 100f);
		upDown = a; // 45);

	}

}