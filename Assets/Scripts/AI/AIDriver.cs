using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDriver : MonoBehaviour {
	private Transform target;
	public float range = 50f;
	public float minrange = 30f;
	public float turnSpd = 6f;
	public bool isin = false;
	public bool interest = false;

	public float rotSpeed;
	Rigidbody rbTank;
	public static float foward;
	public static float left;
	public static float right;
	public int speed;
	//public float health;


	private bool isWanderingD = false;
	private bool isWanderingR = false;
	private bool isDriving = false;
	private bool isRotL = false;
	private bool isRotR = false;


	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.05f);
		speed = 18;
		rotSpeed = 25f;
		StartCoroutine (Interest ());
	}
	IEnumerator Interest(){
		int delay = Random.Range (2, 5);
		int onoff = Random.Range (1, 3);
		yield return new WaitForSeconds (delay);
		if (onoff == 1) {
			interest = false;
		} else if (onoff == 2) {
			interest = true;
		}
		StartCoroutine (Interest ());

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
			isin = false;
		}
	}

	void Awake(){
		rbTank = GetComponent <Rigidbody> ();
	}

	void Update () {
		if (interest == true) {
			if (target == null)
				return;

			Vector3 dir = target.position - transform.position;
			Quaternion lookRot = Quaternion.LookRotation (dir);
			Vector3 rot = Quaternion.Lerp (rbTank.rotation, lookRot, Time.deltaTime * turnSpd).eulerAngles;
			rbTank.rotation = Quaternion.Euler (rbTank.rotation.x, rot.y, rbTank.rotation.z);
		}
		//if (Vector3.Distance (transform.position, target.position) >= minrange && interest == false) {

		//	transform.position += transform.forward * speed * Time.deltaTime;
		//} //else {

		//	return;
		//}

		//cannonRot.rotation = Quaternion.Euler (rot.x, rot.y, 0f);

		foward = speed * Time.deltaTime;
		left = rotSpeed * Time.deltaTime;
		right = rotSpeed * Time.deltaTime;
		if (isin == false || interest == false) {
			if (isWanderingD == false) {
				StartCoroutine (Wander ());
			}
			if (isWanderingR == false) {
				StartCoroutine (Turning ());
			}
			if (isDriving == true) {
				TankFowardBack ();
			}
			if (isRotL == true) {
				TankRotateLeft ();
			}
			if (isRotR == true) {
				TankRotateRight ();
			}
		} //else if (isin == true) {

		//}
		Debug.Log ("Driving" + isDriving);
		Debug.Log ("RotL" + isRotL);
		Debug.Log ("RotR" + isRotR);
	}




	// // // // //


	//void FixedUpdate(){

	//	TankRotateLeftRight ();
	//}
	void TankFowardBack()
	{
		Vector3 moveFB = transform.forward * foward * speed * Time.deltaTime;
		rbTank.MovePosition (rbTank.position + moveFB);
	}
	void TankRotateLeft()
	{
		Quaternion rotateL = Quaternion.Euler (0f, -left, 0f);
		rbTank.MoveRotation (rbTank.rotation * rotateL);
	}
	void TankRotateRight()
	{
		Quaternion rotateR = Quaternion.Euler (0f, right, 0f);
		rbTank.MoveRotation (rbTank.rotation * rotateR);
	}



	// // // // //


	IEnumerator Wander(){
		int driveTime = Random.Range (1, 10);
		int driveWait = Random.Range (1, 5);
		isWanderingD = true;
		yield return new WaitForSeconds(driveWait);
		isDriving = true;
		yield return new WaitForSeconds (driveTime);
		isDriving = false;
		isWanderingD = false;
	}

	IEnumerator Turning(){
		int rotTime = Random.Range (1, 5);
		int rotWait = Random.Range (1, 5);
		int rotLR = Random.Range (1, 3);
		isWanderingR = true;
		yield return new WaitForSeconds (rotWait);
		if (rotLR == 1) {
			isRotR = true;
			yield return new WaitForSeconds (rotTime);
			isRotR = false;
		}
		if (rotLR == 2) {
			isRotL = true;
			yield return new WaitForSeconds (rotTime);
			isRotL = false;
		}

		isWanderingR = false;
	}

}
