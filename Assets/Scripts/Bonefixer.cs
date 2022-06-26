using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonefixer : MonoBehaviour {


	Transform t;

	void Start () {
		t = transform;
	}

	void Update () {
		t.eulerAngles = new Vector3 (0, 0, 0);
	}
}