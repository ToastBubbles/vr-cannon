using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtFreeze : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine( Freeze());
	}
	IEnumerator Freeze(){
		yield return new WaitForSeconds (2);
		//GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY
	}
	// Update is called once per frame
	void Update () {
		
	}
}
