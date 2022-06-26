using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcifier : MonoBehaviour {
	public Transform posForce;
	public GameObject self;
	public GameObject tank;
	public float force;
	public float tankforce;
	//public float tankforce;
	//public float tankrot;

	void Start () {
		tank = GameObject.FindGameObjectWithTag ("Player");
		//force = 10;
		//tankforce = 0;
		//tankrot = 0;
		//StartCoroutine (Timer());
	}


	void Update () {

	}
	void OnTriggerStay(Collider other)
	{
		if (other.attachedRigidbody) {
			other.attachedRigidbody.AddForce (posForce.forward * force);
			other.attachedRigidbody.AddTorque (transform.right * force);


		}
		if (other.tag == "chassisAI") {
			other.attachedRigidbody.AddForce (posForce.forward * tankforce);
			other.attachedRigidbody.AddTorque (transform.right * tankforce);
		}
		//if (other.tag == "chassis") {
		//	tank.GetComponent<Rigidbody> ().AddForce (Vector3.up * tankforce);
		//	tank.GetComponent<Rigidbody> ().AddTorque (transform.right * tankrot);
		//	Debug.Log ("TANKISIN");
		//}
	}
}
