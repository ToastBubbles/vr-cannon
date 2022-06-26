using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpeed : MonoBehaviour {
	//private Renderer rend;
	private CapsuleCollider col;
	public GameObject tank;
	public GameObject tankCar;
	public GameObject bottle;
	public GameObject valve;
	public GameObject nozzle;
	public GameObject handle;
	public GameObject stem;

	void Start () {
		//rend = GetComponentInChildren<Renderer> ();
		col = GetComponent<CapsuleCollider> ();

	}

	private void OnTriggerEnter(Collider other)
	{ 
		if (other.tag == "chassis" || other.tag == "Body" || other.tag == "Cannon") {
		StartCoroutine (Timedspeed ());
		StartCoroutine (Respawn ());

		}
		if (other.tag == "chassisAI" || other.tag == "CannonAI") {
			//StartCoroutine (Timedspeed ());
			//StartCoroutine (Respawn ());
			//Debug.Log (tank.GetComponent<Stats> ().currotSpeed);
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
		if (tankCar.GetComponent<Stats> ().speedLvl < tankCar.GetComponent<Stats> ().speedLvlMax) {

			tankCar.GetComponent<Stats> ().curspeed = tankCar.GetComponent<Stats> ().speedT [tankCar.GetComponent<Stats> ().speedLvl += 1];
			tankCar.GetComponent<Stats> ().currotSpeed = tankCar.GetComponent<Stats> ().rotSpeedT [tankCar.GetComponent<Stats> ().rotSpeedLvl += 1];
			yield return new WaitForSeconds (10);
			tankCar.GetComponent<Stats> ().curspeed = tankCar.GetComponent<Stats> ().speedT [tankCar.GetComponent<Stats> ().speedLvl -= 1];
			tankCar.GetComponent<Stats> ().currotSpeed = tankCar.GetComponent<Stats> ().rotSpeedT [tankCar.GetComponent<Stats> ().rotSpeedLvl -= 1];
		}
	}
	IEnumerator Respawn()
	{
		//rend.enabled = false;
		col.enabled = false;
		bottle.GetComponent<Renderer>().enabled = false;
		valve.GetComponent<Renderer>().enabled = false;
		nozzle.GetComponent<Renderer>().enabled = false;
		handle.GetComponent<Renderer>().enabled = false;
		stem.GetComponent<Renderer>().enabled = false;

		yield return new WaitForSeconds (30);

		//rend.enabled = true;
		col.enabled = true;
		bottle.GetComponent<Renderer>().enabled = true;
		valve.GetComponent<Renderer>().enabled = true;
		nozzle.GetComponent<Renderer>().enabled = true;
		handle.GetComponent<Renderer>().enabled = true;
		stem.GetComponent<Renderer>().enabled = true;
	}
}
