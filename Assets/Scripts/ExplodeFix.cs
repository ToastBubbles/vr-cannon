using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplodeFix : MonoBehaviour {
	public GameObject self;
	public GameObject hp;
	public GameObject shield;
	public GameObject boom;
	public GameObject boom2;
	public GameObject ai;
	private GameObject smartai;
	public Transform posBull;

	public float force = 50.0f;
	public float radius = 5.0f;
	public float upforce = 1.0f;
	public float damage;




	void Start () {
		hp = GameObject.FindGameObjectWithTag ("HP");
		ai = GameObject.FindGameObjectWithTag ("TankAI");
	}

	void FixedUpdate () {



	}
	public void OnTriggerEnter (Collider other) {
		Instantiate (boom, posBull.position, posBull.rotation);
		Instantiate (boom2, posBull.position, posBull.rotation);
		Collider[] colliders = Physics.OverlapSphere (transform.position, radius);

		foreach (Collider nearbyObject in colliders) {
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody> ();
			if (rb != null) {
				rb.AddExplosionForce (force, transform.position, radius);

			}
			else if (nearbyObject.gameObject.tag == "chassis") {
				hp.GetComponent<HealthTrack>().DMG();
				Debug.Log ("CLOSE");
				//hp.GetComponent<Image> ().fillAmount = .3f;
			}
			else if (nearbyObject.gameObject.tag == "chassisAI") {
				
				//nearbyObject.GetComponent<AIHealth>().DMG();
				ai.GetComponent<AIHealth>().DMG();
				Debug.Log ("HITAI");
				//hp.GetComponent<Image> ().fillAmount = .3f;
			}

		}
		Die ();
	}
	void Die(){
		Destroy(self);
	}


}
