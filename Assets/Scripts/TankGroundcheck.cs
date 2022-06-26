using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGroundcheck : MonoBehaviour {
	public bool isin;

	void Start () {

	}


	void Update () {
		Debug.Log(isin + "NIGGERS");
	}
	void FixedUpdate(){
		isin = false;
	}
	private void OnTriggerStay(Collider other)
	{
		isin = true;

	}
}
