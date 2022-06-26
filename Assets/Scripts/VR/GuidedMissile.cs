using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMissile : MonoBehaviour {
	float inc = 1;
	bool rotate = true;
	float decay = 800;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (rotate == true) {
			inc += 0.1f;
			decay -= (1.25f * inc);

			transform.Rotate (Vector3.up * (-1 * decay * (Time.deltaTime)));
			if (decay < 0.3){
				rotate = false;
			}
		}
		//transform.Translate (Vector3.up * ( 10 * Time.deltaTime));
	}
}
