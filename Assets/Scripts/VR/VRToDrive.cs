using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRToDrive : MonoBehaviour {
	public GameObject player;
	public Transform drive;
	bool fx = false;

	void Start(){

		StartCoroutine (Fix ());
	}

	void Update(){
	}
	void OnTriggerEnter(Collider other){
		if (fx == true) {
			player.transform.position = drive.position;
		}

	}


	IEnumerator Fix(){
		yield return new WaitForSeconds (1);
		fx = true;
	}

}
