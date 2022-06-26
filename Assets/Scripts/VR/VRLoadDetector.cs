using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLoadDetector : MonoBehaviour {
	public bool caseIn = false;
	public GameObject pBound;
	private bool projoIn;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		projoIn = pBound.GetComponent<VRLoadPDet> ().projoIn;
		Debug.Log (caseIn + "is its case");
	}
	private void OnTriggerStay(Collider other){
		if (other.gameObject.tag == ("LoadCase")) {
			Debug.Log ("oh CASE, it's in!");
			caseIn = true;
		}
	
	}
	private void OnTriggerExit(Collider other){
		if (other.gameObject.tag == ("LoadCase")) {
			caseIn = false;
		}

	}
}
