using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : MonoBehaviour {
	private GameObject cannon;
	public GameObject col;
	public GameObject selfG;
	public Transform lid;
	public Rigidbody self;
	public Transform slefT;
	//public Collider collider;
	private int runOnce = 0;
	private bool isin = false;


	void Start () {

	}

//	private void OnTriggerEnter(Collider other)
//	{
//		Debug.Log ("AYY NIGGA HE IN");
//		isin = true;
//	}
	public void OnTriggerEnter (Collider other) {
		if (other.tag == "chassis") {
			cannon = GameObject.FindGameObjectWithTag ("Cannon");
			if (cannon.GetComponent<Cannon> () != null) {
				cannon.GetComponent<Cannon> ().maxAmmoSpecial++;
				cannon.GetComponent<Cannon> ().specbull [0] = Random.Range (2, 10);
			}
			if (cannon.GetComponent<CannonVel> () != null) {
				cannon.GetComponent<CannonVel> ().maxAmmoSpecial++;
				cannon.GetComponent<CannonVel> ().specbull [0] = Random.Range (2, 10);
			}
			isin = true;
			col.GetComponent<BoxCollider> ().enabled = false;
		}
		if (other.tag == "chassisAI") {

			isin = true;
			col.GetComponent<BoxCollider> ().enabled = false;
		}
	}


	void Update () {
		//if (lid.transform.localRotation.eulerAngles.z < 100) {
		//	runOnce++;
		//	Debug.Log ("closed");
		//	lid.transform.Rotate (0, 0, 100 * Time.deltaTime);

		//}

		if (lid.transform.localRotation.eulerAngles.z < 100 && isin == true) {
			runOnce++;
			Debug.Log ("closed");
			lid.transform.Rotate (0, 0, 100 * Time.deltaTime);
		}

		if (runOnce == 1) {
			StartCoroutine(Despawn());
		}

	}

	IEnumerator Despawn(){
		self.AddForce (slefT.up * 4, ForceMode.Impulse);
		yield return new WaitForSeconds (4);
		Destroy (selfG);
	}

}
