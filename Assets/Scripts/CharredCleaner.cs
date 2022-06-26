using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharredCleaner : MonoBehaviour {
	public GameObject self;

	void Start () {
		StartCoroutine (Deleter ());
	}
	IEnumerator Deleter(){
		yield return new WaitForSeconds (5);
		Destroy (self);
	}

}
