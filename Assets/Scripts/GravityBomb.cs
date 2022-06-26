using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBomb : MonoBehaviour {
	public Transform selft;
	public GameObject self;
	public GameObject tank;
	public GameObject tankAI;
	public GameObject vortex;
	public float force;
	public float tankforce;
	public float tankrot;

	void Start () {
		tank = GameObject.FindGameObjectWithTag ("Player");
		tankAI = GameObject.FindGameObjectWithTag ("TankAI");
		force = 0;
		tankforce = 0;
		tankrot = 0;
		StartCoroutine (Timer());
	}
	

	void Update () {
		
	}
	void OnTriggerStay(Collider other)
	{
		if (other.attachedRigidbody) {
			other.attachedRigidbody.AddForce (Vector3.up * force);
			other.attachedRigidbody.AddTorque (transform.right * force);

		}
		if (other.tag == "chassis") {
			tank.GetComponent<Rigidbody> ().AddForce (Vector3.up * tankforce);
			tank.GetComponent<Rigidbody> ().AddTorque (transform.right * tankrot);
			Debug.Log ("TANKISIN");
		}
		if (other.tag == "chassisAI") {
			tankAI.GetComponent<Rigidbody> ().AddForce (Vector3.up * tankforce);
			tankAI.GetComponent<Rigidbody> ().AddTorque (transform.right * tankrot);
			Debug.Log ("TANKISIN");
		}
		
	}
	IEnumerator Timer(){
		Instantiate (vortex, selft.position, selft.rotation);
		yield return new WaitForSeconds (1);
		self.GetComponent<Renderer> ().enabled = true;
		force = 10;
		tankforce = 5000000;
		tankrot = -500000;
		yield return new WaitForSeconds (30);
		self.GetComponent<Renderer> ().enabled = false;
		force = 0;
		tankforce = 0;
		tankrot = 0;
		yield return new WaitForSeconds (2);
		Destroy (self);
	}


}
