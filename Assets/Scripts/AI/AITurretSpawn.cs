using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITurretSpawn : MonoBehaviour {
	public GameObject self;
	public GameObject chassis;
	public GameObject turretFxr;
	public Transform turretPosition;
	public Transform rotFix;

	void Start () {
		GameObject turretSpawned;
		turretSpawned = Instantiate (turretFxr, turretPosition.position, rotFix.rotation) as GameObject;
		turretSpawned.transform.parent = self.transform;
	}
}
