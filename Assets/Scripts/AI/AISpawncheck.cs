using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawncheck : MonoBehaviour {
	public bool isin;

	void Start () {
		
	}
	

	void Update () {
		Debug.Log(isin);
	}
	void FixedUpdate(){
		isin = false;
	}
	private void OnTriggerStay(Collider other)
	{
		isin = true;
	
	}
}
