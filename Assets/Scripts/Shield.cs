using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
	public GameObject self;

	void Start(){
		StartCoroutine (Delay ());
	}
	void Update () {
		transform.Rotate(0, 10 * Time.deltaTime, 0);
	}
	IEnumerator Delay(){
		yield return new WaitForSeconds (25);
		Destroy (self);
	}
}
