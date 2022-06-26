using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplodeDirt: MonoBehaviour {
	public GameObject self;
	public GameObject boom;
	public Transform posBull;


	void Start () {

	}

	void FixedUpdate () {
	}
	public void OnTriggerEnter (Collider other) {
		Instantiate (boom, posBull.position, posBull.rotation);
		Die ();
	}
	void Die(){
		Destroy(self);
	}


}
