using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplodeGrav : MonoBehaviour {
	public GameObject self;
	public GameObject hp;
	public GameObject shield;
	public GameObject boom;
	public Transform posBull;

	public float force = 50.0f;
	public float radius = 5.0f;
	public float upforce = 1.0f;
	public float damage;

	public Vector3 masser;




	void Start () {
		hp = GameObject.FindGameObjectWithTag ("HP");

	}

	void FixedUpdate () {

		float gg = damage;
		Debug.Log(gg + "is dmg");
		if(Input.GetKeyDown("g")){
			hp.GetComponent<Image>().fillAmount = .3f;
		}

	}
	public void OnTriggerEnter (Collider other) {
		Instantiate (boom, posBull.position, Quaternion.identity);
		Collider[] colliders = Physics.OverlapSphere (transform.position, radius);

		foreach (Collider nearbyObject in colliders) {
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody> ();
			if (rb != null) {
				//Vector3 offset = transform.position - nearbyObject.transform.position;
				//rb.AddForce (offset / offset.sqrMagnitude * rb.mass, ForceMode.Force);
				//rb.AddForce (masser, ForceMode.Force);


			}

		}
		Die ();
	}
	void Die(){
		Destroy(self);
	}


}
