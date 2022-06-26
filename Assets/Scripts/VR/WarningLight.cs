using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningLight : MonoBehaviour {
	Light lt;
	public bool damaged = false;
	float intense = 0;

	void Start () {
		lt = GetComponent<Light> ();
		lt.intensity = 0;
		StartCoroutine (On ());
		damaged = false;
	}
	

	void Update () {
		lt.intensity = intense;

	}




	IEnumerator On(){
		while (true) {
			if (damaged == true) {
				if (intense == 0) {
					intense = 2;
				} else if (intense == 2) {
					intense = 0;
				}
				yield return new WaitForSeconds (1);
			}
		}

	}
}
