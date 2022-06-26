using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplosionForce : MonoBehaviour {
	public GameObject explosion;
	public float power = 10.0f;
	public float radius = 5.0f;
	public float upforce = 1.0f;



	// Use this for initialization
	void Start () {
		
	}
	

	void FixedUpdate () {
		//if (projo == Destroy) {
			Invoke ("Detonate", 1);
		//}
	}

	void Detonate () {
		Vector3 explosionPosition= explosion.transform.position;
		Collider[] colliders = Physics.OverlapSphere (explosionPosition, radius);
		foreach (Collider hit in colliders) {
			Rigidbody rb = hit.GetComponent<Rigidbody> ();
			if (rb != null) {
				rb.AddExplosionForce (power, explosionPosition, radius, upforce, ForceMode.Impulse);

			}
		}
	}
}
