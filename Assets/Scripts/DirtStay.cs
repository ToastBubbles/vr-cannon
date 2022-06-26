using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtStay : MonoBehaviour {
	//public GameObject self;
	//public GameObject dirt;
	Rigidbody rb;

	void Start () {
		StartCoroutine (Delay ());
	}
	

	void Update () {
		
	}

	IEnumerator Delay(){
		yield return new WaitForSeconds (2);
		//dirt = GameObject.FindGameObjectWithTag ("Dirt");
		//self.GetComponentInChildren<Rigidbody> ().constraints =
		rb = GetComponent<Rigidbody>();

		rb.constraints = RigidbodyConstraints.FreezePosition;


		Debug.Log ("DIRT");
	}
}
