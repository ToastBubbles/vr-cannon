using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour {
	public bool reset = false;
	public bool tellreset = false;
	public GameObject pressedPos;
	float speed;
	Vector3 startPos;

	void Start () {
		startPos = transform.position;
	}
	

	void Update () {
		tellreset = reset;
		if (reset == true) {
			
		}
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == ("Hand")) {
			reset = true;

		}
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == ("Hand")) {
			reset = false;
		}
	}


}
