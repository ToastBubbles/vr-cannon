using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTurrectLR : MonoBehaviour {
	private GameObject controlCrank;
	private float leftright;
	private Quaternion m_OriginalRotation;

	private void Start()
	{
		controlCrank= GameObject.FindGameObjectWithTag ("TurretCrank");
		m_OriginalRotation = transform.localRotation;
	}


	void Update () {
		transform.localRotation = m_OriginalRotation;
		if (controlCrank) {

			leftright = controlCrank.GetComponent<VRTurretCrank> ().rot;
			Debug.Log (leftright);
			//Vector3 temp = new Vector3 (updown, transform.localRotation.y, transform.localRotation.z);

			transform.localRotation = m_OriginalRotation * Quaternion.Euler (transform.localRotation.x, transform.localRotation.y, leftright);
		}
	}
}