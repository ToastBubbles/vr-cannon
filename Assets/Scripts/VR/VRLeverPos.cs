using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLeverPos : MonoBehaviour {
	public Transform trans;

	void Update () {
		transform.position = trans.position;
	}
}
