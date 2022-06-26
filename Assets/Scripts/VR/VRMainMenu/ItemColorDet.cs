using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColorDet : MonoBehaviour {
	public string curItem = "null";
	private bool itemIn;

	void Start () {

	}


	void Update () {
		Debug.Log (curItem + "is inside");
		Debug.Log (itemIn + "is its case");
		//Debug.Log (standard + "is standard");
	}
	private void OnTriggerStay(Collider other){
		if (other.gameObject.tag == ("Tank") || other.gameObject.tag == ("Turret")) {
			itemIn = true;
			curItem = other.gameObject.name;
		}// else if (other.gameObject.tag == ("Turret")) {
			//itemIn = true;
			//curItem = other.gameObject.name;
		//}

	}
	private void OnTriggerExit(Collider other){
		if (other.gameObject.tag == ("Tank") || other.gameObject.tag == ("Turret")) {
			itemIn = false;
			curItem = "null";
		} //else if (other.gameObject.tag == ("Turret")) {
			//itemIn = false;
			//curItem = "null";
		//}

	}

}
