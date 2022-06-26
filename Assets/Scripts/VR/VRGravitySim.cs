using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGravitySim : MonoBehaviour {
	private float thrust = 1f;
	public Rigidbody rb;
	public Transform target;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		rb.AddForce((target.position - transform.position) * thrust);
	}
}