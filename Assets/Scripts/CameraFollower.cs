using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {
	public GameObject self;
	public GameObject cam2;
	//public GameObject tank;
	public Transform target;
	public Transform bar;
	//public Transform camPos;
	public GameObject zoomPos;
	public GameObject camPosKeeper;
	public GameObject hp;
	public GameObject bck;
	//public Vector3 offset;
	public Vector3 offset2;
	private bool runOnce;
	private bool oneSpawn;
	public bool zoomed = false;
	private bool checker = false;
	void Start(){
		runOnce = true;
		oneSpawn = false;
		zoomPos = GameObject.FindGameObjectWithTag ("zoom");
		cam2 = GameObject.FindGameObjectWithTag ("zoomCam");
		if (cam2 != null) {
			cam2.SetActive (false);
		}
	}
	void FixedUpdate () {
		
		target = GameObject.FindGameObjectWithTag ("Cannon").transform;
		bar = GameObject.FindGameObjectWithTag ("Barrel").transform;


	}

		//cam2.SetActive (false);
	
	void Update(){

		if (Input.GetMouseButtonDown (1) && zoomed == false) {
			cam2.SetActive(true);
			self.SetActive(false);
			zoomed = true;
			//camPos.transform.position = zoomPos.transform.position;
		} else if (Input.GetMouseButtonDown (1) && zoomed == true) {
			//camPos.transform.position = camPosKeeper.transform.position;// + (offset);
			self.SetActive(true);
			cam2.SetActive(false);
			zoomed = false;
		}
		if (zoomed == true) {
			//camPos.rotation = bar.rotation;
			//camPos.SetParent (bar);
		}
	}
	void LateUpdate () {
		if (hp.GetComponent<HealthTrack> ().cam == false) {
			self.transform.SetParent (target);
			camPosKeeper.transform.SetParent (target);
			zoomPos.transform.SetParent (bar);
		} else if (hp.GetComponent<HealthTrack> ().cam == true) {
			oneSpawn = true;
			Debug.Log ("wew");
		}
		if (runOnce == true) {
			self.transform.position = target.transform.position + (offset2);
			camPosKeeper.transform.position = target.transform.position + (offset2);
			runOnce = false;
			return;
		}


	} 

}