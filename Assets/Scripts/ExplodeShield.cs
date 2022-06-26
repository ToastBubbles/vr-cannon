using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplodeShield : MonoBehaviour {
	public GameObject self;
	public GameObject boom;
	public Transform posBull;


	void Start () {

	}

	void FixedUpdate () {
	}
	public void OnTriggerEnter (Collider other) {
		GameObject temp;
		temp = Instantiate (boom, posBull.position, Quaternion.identity) as GameObject;
		Die ();
	}
	void Die(){
		Destroy(self);
	}


}
