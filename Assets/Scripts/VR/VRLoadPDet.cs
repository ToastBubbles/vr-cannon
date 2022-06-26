using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLoadPDet : MonoBehaviour {
	public bool projoIn = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (projoIn + "is its stat");
	}
	private void OnTriggerStay(Collider other){
		if (other.tag == ("LoadProjo")) {
			Debug.Log ("oh fuck yes, it's in!");
			projoIn = true;
		}

	}
	private void OnTriggerExit(Collider other){
		if (other.tag == ("LoadProjo")) {
			projoIn = false;
		}
	}
}
