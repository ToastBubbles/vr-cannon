using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCameraSprite : MonoBehaviour {
	private GameObject cam2;
	private bool deathcheck;
	public GameObject aiTank;

	void Start () {
		cam2 = GameObject.FindGameObjectWithTag ("zoomCam");
	}
	

	void Update () {
		//deathcheck = aiTank.GetComponent<AIHealth> ().isalive;
		if (Camera.main){// && deathcheck == true) {
			transform.LookAt (Camera.main.transform.position, -Vector3.up);
		}// else if (cam2 && deathcheck == true) {
		//	transform.LookAt (cam2.transform.position, -Vector3.up);
		//}
	}
}
