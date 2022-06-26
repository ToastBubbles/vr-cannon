using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRedLever : MonoBehaviour {

	public float upDown;
	public float fixer;


	void FixedUpdate(){
		float a = (transform.localRotation.eulerAngles.x);

		upDown = (1-(((a-270)/90))); // 45);
		if (upDown > 1) {
			fixer = 0;
		} else {
			fixer = upDown;
		}
		//Debug.Log(fixer);
		//Debug.Log (a);

	}
}
