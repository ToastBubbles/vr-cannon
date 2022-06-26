using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRtankRotation : MonoBehaviour {
	public GameObject tank;



	void Start () {
		
	}
	

	void Update () {
		transform.rotation = tank.transform.rotation;
	}
}
