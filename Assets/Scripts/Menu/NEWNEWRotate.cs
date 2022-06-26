using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWNEWRotate : MonoBehaviour {
	
	private float speed = 5f;
	private float stepspeed = 75f;
	private float stepslow = 3f;

	private int current;
	private int currentturret;
	public int max;
	public int maxturret;
	public GameObject camera;
	public GameObject turretStan;
	public GameObject turret2;
	public GameObject turretmort;
	public GameObject tankStandard;
	public GameObject tankWheels;
	public Transform aturpos;
	public Transform aturposw;
	public Transform atankpos;
	public Transform unsel;
	public Transform standardcamPos;
	public Transform wheelcamPos;
	private GameObject activetank;
	private GameObject activetur;
	public int seltank;
	public int seltur;
	private Vector3 adjuster;

	void Start () {
		activetank = tankStandard;
		activetur = turretStan;
		current = 0;
		currentturret = 0;



	}

	void Awake(){

			
	}


	void Update () {
		//sets numerical value for selected parts

		if (activetank == tankStandard) {
			seltank = 0;
		}else if (activetank == tankWheels) {
			seltank = 1;
		}
		if (activetur == turretStan) {
			seltur = 0;
		}else if (activetur == turret2) {
			seltur = 1;
		}else if (activetur == turretmort) {
			seltur = 2;
		}
		Debug.Log (seltur);

		Debug.Log (activetank.gameObject.name);
		adjuster = new Vector3 (aturpos.transform.position.x, aturpos.transform.position.y + 20, aturpos.transform.position.z);
		float step =  stepspeed * Time.deltaTime;
		float slow = stepslow * Time.deltaTime;

		transform.Rotate(Vector3.up * Time.deltaTime * speed);

		if (Input.GetKeyDown("e") && current < max) {
			activetank = tankWheels;
			current++;
		}else if(Input.GetKeyDown("e") && current == max){
			activetank = tankStandard;
			current = 0;
		}
		if (Input.GetKeyDown ("q") && currentturret == 0) {
			currentturret++;
			activetur = turret2;
		}else if(Input.GetKeyDown("q") && currentturret == 1){
			currentturret++;
			activetur = turretmort;
		}else if(Input.GetKeyDown("q") && currentturret == maxturret){
			currentturret = 0;
			activetur = turretStan;
		}


		if (activetank == tankStandard) {
			camera.transform.position = Vector3.MoveTowards(camera.transform.position, standardcamPos.position, slow);
			tankStandard.transform.position = Vector3.MoveTowards (tankStandard.transform.position, atankpos.transform.position, step);
			if (activetur.transform.position == unsel.transform.position) {
				activetur.transform.position = Vector3.MoveTowards (activetur.transform.position, aturpos.transform.position, step);
			} else {
				activetur.transform.position = Vector3.MoveTowards (activetur.transform.position, aturpos.transform.position, step);
			}
//			if (aturpos.transform.position == unatur.transform.position) {
//				aturpos.transform.position = Vector3.MoveTowards (unatur.transform.position, aturpos.transform.position, step);
//			} else {
//				aturpos.transform.position = Vector3.MoveTowards (adjuster, aturpos.transform.position, step);
//			}
		}
		if (activetank == tankWheels) {
			camera.transform.position = Vector3.MoveTowards(camera.transform.position, wheelcamPos.position, slow);
			tankWheels.transform.position = Vector3.MoveTowards (tankWheels.transform.position, atankpos.transform.position, step);
			if (activetur.transform.position == unsel.transform.position) {
				activetur.transform.position = Vector3.MoveTowards (activetur.transform.position, aturposw.transform.position, step);
			} else{
				activetur.transform.position = Vector3.MoveTowards (activetur.transform.position, aturposw.transform.position, step);
			}
//			if (aturpos.transform.position == unatur.transform.position) {
//				aturpos.transform.position = Vector3.MoveTowards (unatur.transform.position, adjuster, step);
//			} else {
//				aturpos.transform.position = Vector3.MoveTowards (aturpos.transform.position, adjuster, step);
//			}
		}
		if (activetank != tankStandard) {
			tankStandard.transform.position = Vector3.MoveTowards (tankStandard.transform.position, unsel.transform.position, step);
		}
		if (activetank != tankWheels) {
			tankWheels.transform.position = Vector3.MoveTowards (tankWheels.transform.position, unsel.transform.position, step);
		}
		if (turretStan != activetur) {
			turretStan.transform.position = Vector3.MoveTowards (turretStan.transform.position, unsel.transform.position, step);
		}
		if (turret2 != activetur) {
			turret2.transform.position = Vector3.MoveTowards (turret2.transform.position, unsel.transform.position, step);
		}
		if (turretmort != activetur) {
			turretmort.transform.position = Vector3.MoveTowards (turretmort.transform.position, unsel.transform.position, step);
		}
	}
}