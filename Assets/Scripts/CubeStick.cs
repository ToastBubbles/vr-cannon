using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStick : MonoBehaviour {
	//public GameObject self;
	public Rigidbody rb;
	public Vector3 lossy;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	void OnTriggerEnter (Collider other) {
		//toast.GetComponent<Rigidbody>().enabled = false;
		//gameObject.GetComponent<Transform>().SetParent(gameObject);
		//transform.localScale = lossy;
		transform.parent = other.transform;
		//transform.localScale = lossy;
		//rb.isKinematic = true;
		//Destroy(toast.GetComponent<Rigidbody>());
		Destroy(rb);
	}

	void Update () {

	}
}
