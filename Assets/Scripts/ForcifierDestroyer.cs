using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcifierDestroyer : MonoBehaviour {
	public bool remover;
	public GameObject self;
	void Start () {
		remover = false;
	}

	void FixedUpdate () {
		if (remover == true) {
			Debug.Log ("removed");
			Destroy (self);
		}
	}
	public void Die(){
		Debug.Log ("removed2");
		Destroy (self);
	}
}
