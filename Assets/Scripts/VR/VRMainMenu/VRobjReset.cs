using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRobjReset : MonoBehaviour {
	public Transform tur1p;
	public Transform tur2p;
	public Transform tank1p;
	public Transform tank2p;
	public GameObject tur1;
	public GameObject tur2;
	public GameObject tank1;
	public GameObject tank2;

	public GameObject caller;
	private bool reset = false;

	void Start () {
		tur1p.transform.SetPositionAndRotation (tur1.transform.position, tur1.transform.rotation);
		tur2p.transform.SetPositionAndRotation (tur2.transform.position, tur2.transform.rotation);
		tank1p.transform.SetPositionAndRotation (tank1.transform.position, tank1.transform.rotation);
		tank2p.transform.SetPositionAndRotation (tank2.transform.position, tank2.transform.rotation);
	}
	

	void Update () {
		//reset = caller.GetComponent<LaserVR> ().resetter;
		if (reset == true) {
			Reset ();
		}
	}

	public void Reset(){
		tur1.transform.SetPositionAndRotation (tur1p.position, tur1p.rotation);
		tur2.transform.SetPositionAndRotation (tur2p.position, tur2p.rotation);
		tank1.transform.SetPositionAndRotation (tank1p.position, tank1p.rotation);
		tank2.transform.SetPositionAndRotation (tank2p.position, tank2p.rotation);

	}
}
