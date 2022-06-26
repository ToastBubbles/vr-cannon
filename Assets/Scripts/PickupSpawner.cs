using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour {
	//private int randx;
	//private int randz;
	//private int randpu;
	public GameObject pickupAmmo;
	public GameObject ammoCan;
	private bool isSpawning = false;
	public int timeSetting;

	void Start () {
		
	}

	void Update () {
		if (isSpawning == false) {
			StartCoroutine (Spawn ());
		}
	}

	IEnumerator Spawn(){
		int randx = Random.Range (-200, 100);
		int randz = Random.Range (-200, 100);
		int randx2 = Random.Range (-200, 100);
		int randz2 = Random.Range (-200, 100);
		int randpu = Random.Range (1, 2);
		int delay = Random.Range (2, 15);
		int time = delay + timeSetting;
		GameObject pickup;
		GameObject can;
		Vector3 point = new Vector3 (randx, 300, randz);
		Vector3 point2 = new Vector3 (randx2, 200, randz2);
		isSpawning = true;

		yield return new WaitForSeconds (time);
		pickup = Instantiate (pickupAmmo, point, Quaternion.Euler(0, Random.Range(0, 360), 0)) as GameObject;
		can = Instantiate (ammoCan, point2, Quaternion.Euler(0, Random.Range(0, 360), 0)) as GameObject;


		isSpawning = false;
	}
}
