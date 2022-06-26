using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTurretBarrel : MonoBehaviour {
	private GameObject controlLever;
	private float updown;
	private Quaternion m_OriginalRotation;

	private void Start()
	{
		controlLever = GameObject.FindGameObjectWithTag ("TurretLever");
		m_OriginalRotation = transform.localRotation;
	}
	

	void Update () {
		transform.localRotation = m_OriginalRotation;
		if (controlLever) {

			updown = controlLever.GetComponent<VRTurretBarrelUpDown> ().upDown;
			Debug.Log (updown);
			//Vector3 temp = new Vector3 (updown, transform.localRotation.y, transform.localRotation.z);

			transform.localRotation = m_OriginalRotation * Quaternion.Euler (updown, transform.localRotation.y, transform.localRotation.z);
		}
	}
}
