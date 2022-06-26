using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTankSave : MonoBehaviour {
	//public bool standard = false;
	//public bool wheels = false;
	public string curTank = "null";
	private bool tankIn;

	void Start () {

	}


	void Update () {
		Debug.Log (curTank + "is the tank");
		Debug.Log (tankIn + "is its case");
		//Debug.Log (standard + "is standard");
	}
	private void OnTriggerStay(Collider other){
		if (other.gameObject.tag == ("Tank")) {
			tankIn = true;
			curTank = other.gameObject.name;
		}

	}
	private void OnTriggerExit(Collider other){
		if (other.gameObject.tag == ("Tank")) {
			tankIn = false;
			curTank = "null";
		}

	}

}
