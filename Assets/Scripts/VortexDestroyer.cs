using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexDestroyer : MonoBehaviour {
	public GameObject self;
	void Start () {
		StartCoroutine (Time ());
	}
	IEnumerator Time(){
		yield return new WaitForSeconds (1);
		Destroy (self);
	}
}
