using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malfunctioner : MonoBehaviour {
	public GameObject player;
	//public Camera camM;
	public GameObject cam;
	//public Camera zoom;
	private bool isCamSpin = false;
	public int effectTime = 7;
	public int effectNum = 5;

	//save values
	private Vector3 camMRot;
	float cx, cy;
	float farplane;

	void Start () {
		//Declaration
		player = GameObject.FindGameObjectWithTag ("Player");
//		camM = GameObject.Find("Main Camera").GetComponent<Camera>();

		//save MC values
//		cx = camM.transform.eulerAngles.x;
//		cy = camM.transform.eulerAngles.y;
		camMRot.x = cx;
		camMRot.y = cy;
		camMRot.z = 0;

//		farplane = camM.farClipPlane;

		//RandSel ();

	}

	void Update () {
		//for CamSpin
		if (isCamSpin == true) {
//			camM.transform.Rotate (Vector3.forward * 12f);
		}


	}
	void RandSel(){
		int r = Random.Range (0, effectNum);
		if (r == 0) {
			StartCoroutine (FoV());
		}else if (r == 1) {
			StartCoroutine (CamSpin());
		}else if (r == 2) {
			StartCoroutine (Blind());
		}else if (r == 3) {
			StartCoroutine (Drive());
		}else if (r == 4) {
			StartCoroutine (Rotate());
		}
	}

	IEnumerator FoV(){
//		camM.fieldOfView = camM.fieldOfView + 80;
		yield return new WaitForSeconds (effectTime);
//		camM.fieldOfView = camM.fieldOfView - 80;
	}
	IEnumerator CamSpin(){
		isCamSpin = true;
		yield return new WaitForSeconds (effectTime);
		isCamSpin = false;
//		camM.transform.eulerAngles = camMRot;
	}
	IEnumerator Blind(){
//		camM.farClipPlane = 40;
		yield return new WaitForSeconds (effectTime);
//		camM.farClipPlane = farplane;
	}
	IEnumerator Drive(){
		int rand = Random.Range (0, 2);
		int bf = -2;
		if (rand == 1) {
			bf = 2;
		}
		player.GetComponent<EasyDrive>().malfunction = bf;
		yield return new WaitForSeconds (effectTime);
		player.GetComponent<EasyDrive>().malfunction = 0;
	}
	IEnumerator Rotate(){
		int rand = Random.Range (0, 2);
		int rl = -4;
		if (rand == 1) {
			rl = 4;
		}
		player.GetComponent<EasyDrive>().malfunctionR = rl;
		yield return new WaitForSeconds (effectTime);
		player.GetComponent<EasyDrive>().malfunctionR = 0;
	}
	//upside down cam

}
