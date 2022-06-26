using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReset : MonoBehaviour {
	Vector3 pos;
	Quaternion rot;
	GameObject button;
	bool res;

	void Start () {
		button = GameObject.FindGameObjectWithTag ("button");
		pos = transform.position;
		rot = transform.rotation;
	}
	

	void Update () {
		res = button.GetComponent<ResetButton> ().reset;
		if (res == true) {
			Reset();
		}
	}

	void Reset(){
		transform.position = pos;
		transform.rotation = rot;
		if (GetComponent<Rigidbody>() != null) {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
	}
}
