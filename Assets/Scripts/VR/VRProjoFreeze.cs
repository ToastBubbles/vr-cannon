using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRProjoFreeze : MonoBehaviour {
	public GameObject button;
	public GameObject vector;
//	public Transform endP;
//	public Transform startP;
	private bool loader = false;
	private bool isin = false;
	private bool returner = false;
	private bool delay  = false;
	public float speed = 3f;


	void Start () {
		
	}
	

	void Update () {
		returner = button.GetComponent<VRLoad> ().returnP;
		loader = button.GetComponent<VRLoad> ().load;
/*		if (loader == true) {
			vector.transform.position = Vector3.Lerp (vector.transform.position, endP.position, speed);
		}
		if (returner == true) {
			vector.transform.position = Vector3.Lerp (vector.transform.position, startP.position, speed);
		}*/
	}
	private void OnTriggerStay(Collider other){
		if (other.tag == ("Shell") && loader == true) {

			Debug.Log ("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");

			other.attachedRigidbody.isKinematic = true;
			other.transform.parent = vector.transform;
			isin = true;


		}

	}
	IEnumerator Delay(){
		yield return new WaitForSeconds (1);
		delay = true;
	}

	private void OnTriggerExit(Collider other){
		if (other.tag == ("Shell")) {
			
		}
	}
}
