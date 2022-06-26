using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explode : MonoBehaviour {
	public GameObject self;
	public GameObject hp;
	public GameObject boom;
	public Transform posBull;

	public float force = 50.0f;
	public float radius = 500.0f;
	public float upforce = 1.0f;
	public float damage;

	void Start () {
	}
	public void DMG (){
		damage = 5f;
		damage++;
		Debug.Log (damage);
	}

	void FixedUpdate () {
		float gg = damage;
		Debug.Log(gg + "is dmg");
	}
	public void OnTriggerEnter (Collider other) {
		Instantiate (boom, posBull.position, posBull.rotation);
		Collider[] colliders = Physics.OverlapSphere (transform.position, radius);
	
		foreach (Collider nearbyObject in colliders) {
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody> ();
			if (rb != null) {
				rb.AddExplosionForce (force, transform.position, radius);
			} else if (nearbyObject.gameObject.tag == "chassis") {
				//hp.GetComponent<HealthTrack>().test = 1;
				DMG ();
				Debug.Log ("HitSelf");
			}else if (nearbyObject.gameObject.tag == "chassisAI") {
				//hp.GetComponent<HealthTrack>().test = 1;
				DMG ();
				Debug.Log ("HitAI");
			}
		}
		Die ();
	}
	void Die(){
		Destroy(self);
	}
}
