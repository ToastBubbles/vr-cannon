using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTurnWheel : MonoBehaviour {
	public float speed;
	public float minAngle;
	public float maxAngle;
	private float rotationZ = 0f;
	private float sensitivityX = 2f;
	public float turnForce;

	void OnMouseDrag(){
		//float rotX = Input.GetAxis ("Mouse Y") * speed * Mathf.Deg2Rad;
		//transform.RotateAround (Vector3.right, rotX);


	}
	void Start(){
		
	}

	void FixedUpdate(){
		lockedRotation ();

		turnForce = (rotationZ)/180;
		//Debug.Log ("ISyourturn" + driveForce);
		if (-3f < rotationZ && rotationZ < 3f) {
			rotationZ = 0f;
		}
	}
	void lockedRotation()
	{
		rotationZ += Input.GetAxis("Mouse X") * sensitivityX;
		rotationZ = Mathf.Clamp (rotationZ, minAngle, maxAngle);

		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, rotationZ);
	}
}