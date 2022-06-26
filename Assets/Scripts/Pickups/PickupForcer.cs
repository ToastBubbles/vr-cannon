using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupForcer : MonoBehaviour {
	private Renderer rend;
	private BoxCollider box;
	public GameObject tank;

	void Start () {
		rend = GetComponent<Renderer> ();
		box = GetComponent<BoxCollider> ();

	}

	void Update () {
		transform.Rotate(0, 0, 90 * Time.deltaTime);
	}
	private void OnTriggerEnter(Collider other)
	{ 
		if (other.tag == "chassis" || other.tag == "Body" || other.tag == "Cannon") {
			StartCoroutine (Timedspeed ());
			StartCoroutine (Respawn ());
		}
		if (other.tag == "chassisAI" || other.tag == "CannonAI") {
		}
	}


	IEnumerator Timedspeed()
	{
		if (tank.GetComponent<Stats> ().speedLvl < tank.GetComponent<Stats> ().speedLvlMax) {

			tank.GetComponent<Stats> ().curspeed = tank.GetComponent<Stats> ().speedT [tank.GetComponent<Stats> ().speedLvl += 1];
			tank.GetComponent<Stats> ().currotSpeed = tank.GetComponent<Stats> ().rotSpeedT [tank.GetComponent<Stats> ().rotSpeedLvl += 1];
			yield return new WaitForSeconds (10);
			tank.GetComponent<Stats> ().curspeed = tank.GetComponent<Stats> ().speedT [tank.GetComponent<Stats> ().speedLvl -= 1];
			tank.GetComponent<Stats> ().currotSpeed = tank.GetComponent<Stats> ().rotSpeedT [tank.GetComponent<Stats> ().rotSpeedLvl -= 1];

		}
	}
	IEnumerator Respawn()
	{
		rend.enabled = false;
		box.enabled = false;
		yield return new WaitForSeconds (30);
		rend.enabled = true;
		box.enabled = true;
	}
}
