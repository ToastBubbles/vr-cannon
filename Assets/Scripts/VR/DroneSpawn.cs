using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawn : MonoBehaviour {
	public GameObject insideDrone;
	public GameObject sDrone;
	public Transform spawnP;

	void Start () {
		
	}
	

	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == ("Drone")) {
			SpawnDrone ();
			Destroy (other.gameObject);
		}
	}

	void SpawnDrone(){
		Debug.Log("Spawned");
		GameObject drone;
		drone = Instantiate (sDrone, spawnP.position, spawnP.rotation) as GameObject;
	}
}
