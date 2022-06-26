using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTurretSave : MonoBehaviour {
	public string curTur = "null";
	private bool turIn;

	void Start () {

	}


	void Update () {
		Debug.Log (curTur + "is the turret");
	}
	private void OnTriggerStay(Collider other){
		if (other.gameObject.tag == ("Turret")) {
			turIn = true;
			curTur = other.gameObject.name;
		}

	}
	private void OnTriggerExit(Collider other){
		if (other.gameObject.tag == ("Turret")) {
			turIn = false;
			curTur = "null";
		}

	}
}
