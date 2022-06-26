using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRBulletSpawner : MonoBehaviour {
	public Rigidbody heP;
	public Rigidbody fP;
	private int i = 0;

	void Start () {

	}
	

	void Update () {

		if (i < 3){
			
			Rigidbody heR;
			heR = Instantiate (fP, transform.position, fP.rotation) as Rigidbody;

		}
		i++;
	}
}
