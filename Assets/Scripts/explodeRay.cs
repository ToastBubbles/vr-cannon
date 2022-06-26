using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeRay : MonoBehaviour {
	public GameObject self;
	public GameObject boom;
	public Transform posBull;
	public float force = 500.0f;
	public float radius = 50.0f;
	public float upforce = 1.0f;
	Vector3 mPrevPos;

	// Use this for initialization
	void Start () {
		mPrevPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		mPrevPos = transform.position;
		RaycastHit[] hits = Physics.RaycastAll(new Ray(mPrevPos, (transform.position - mPrevPos).normalized), (transform.position - mPrevPos).magnitude);
		for(int i = 0; i < hits.Length; i++){
			Debug.Log(hits[i].collider.gameObject.name);
			Debug.Log ("gg");
		}
	}
	//void OnTriggerEnter (Collider other) {
	//	Instantiate (boom, posBull.position, posBull.rotation);
	//	Collider[] colliders = Physics.OverlapSphere (transform.position, radius);
	//
	//	foreach (Collider nearbyObject in colliders) {
	//		Rigidbody rb = nearbyObject.GetComponent<Rigidbody> ();
	//		if (rb != null) {
	//			rb.AddExplosionForce (force, transform.position, radius);
	//		}
	//	}
	//	Destroy(self);
	//}
}
