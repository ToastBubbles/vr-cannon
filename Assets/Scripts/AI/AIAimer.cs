using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAimer : MonoBehaviour {
	private Transform target;
	public float range = 50f;
    private float close = 3f;
	public float turnSpd = 6f;

	public Transform tank;
	public Transform turretRot;
	public Transform cannonRot;
	public Transform reseter;
	public Transform test;


	public ParticleSystem flash;
	public Rigidbody projo1;
	public Transform posCan;
	public float forceAmount;
	public int cur;
	float counter = 0;
	public bool isin = false;
	public bool peaceful;




	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.05f);
		StartCoroutine (Cooldown ());

	}

	void UpdateTarget () {
		GameObject enemy = GameObject.FindGameObjectWithTag ("Player");
		target = enemy.transform;
		float distanceToPlayer = Vector3.Distance (transform.position, enemy.transform.position);
		if (distanceToPlayer < range) {
			Debug.Log ("in Range");
			isin = true;



		} else {
			target = null;
			Debug.Log ("out of range");
			//turretRot.rotation = reseter.rotation;
			isin = false;
		}
	}
	IEnumerator Cooldown(){
		int rand = Random.Range (2, 6);
		counter = 0;
		yield return new WaitForSeconds (rand);
		counter = 1;
	}

	void Update () {
		if (target == null)
			return;

		Vector3 dir = target.position - transform.position;
		Quaternion lookRot = Quaternion.LookRotation (dir);
		Vector3 rot = Quaternion.Lerp(turretRot.rotation, lookRot, Time.deltaTime * turnSpd).eulerAngles;
		turretRot.rotation = Quaternion.Euler (test.rotation.x, rot.y, test.rotation.z);
		cannonRot.rotation = Quaternion.Euler (rot.x, rot.y, 0f);

//		Vector3 dir = target.position - transform.position;
//		Quaternion lookRot = Quaternion.LookRotation (dir);
//		Vector3 rot = Quaternion.Lerp(turretRot.rotation, lookRot, Time.deltaTime * turnSpd).eulerAngles;
//		turretRot.rotation = Quaternion.Euler (tank.localRotation.x, rot.y, tank.localRotation.z);
//		cannonRot.rotation = Quaternion.Euler (rot.x, rot.y, 0f);

		if (counter == 1 && isin == true && peaceful == false) {
			Rigidbody bullet;
			bullet = Instantiate (projo1, posCan.position, posCan.rotation) as Rigidbody;
			bullet.AddForce (posCan.forward * forceAmount);
			flash.Emit (50);
			StartCoroutine (Cooldown ());
		}

	}

	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
