using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newRotator : MonoBehaviour {
	private float speed = 5f;
	private float stepspeed = 75f;
	private float stepslow = 3f;
	public GameObject tankStandard;
	public GameObject tankWheels;
	public GameObject turretStan;
	public GameObject turret2;
	public GameObject turretmort;
	public GameObject camera;
	public Transform standardPos;
	public Transform wheelPos;
	public Transform standardcamPos;
	public Transform wheelcamPos;
	public Transform target;
	public Transform target2;
	public Transform target1Stand;
	public Transform targetWhO;

	public Transform targetmorstansel;
	public Transform targetmorwheelsel;
	public Transform targetmoror;

	public Transform targettank;
	public Transform targettankcar;
	private int current;
	private int currentturret;
	public int max;
	public int maxturret;

	void Start () {
		current = 0;
		currentturret = 0;

	}


	void Update () {
		float step =  stepspeed * Time.deltaTime;
		float slow = stepslow * Time.deltaTime;

		transform.Rotate(Vector3.up * Time.deltaTime * speed);

		if (Input.GetKeyDown("e") && current < max) {
			current++;
		}else if(Input.GetKeyDown("e") && current == max){
			current = 0;
		}
		if (Input.GetKeyDown ("q") && currentturret == 0) {
			currentturret++;
		}else if(Input.GetKeyDown("q") && currentturret == 1){
			currentturret++;
		}else if(Input.GetKeyDown("q") && currentturret == maxturret){
			currentturret = 0;
		}

		if(current == 0){

			tankWheels.transform.position = Vector3.MoveTowards(tankWheels.transform.position, targetWhO.position, step);
			tankStandard.transform.position = Vector3.MoveTowards(tankStandard.transform.position, target1Stand.position, step);
			turretStan.transform.position = Vector3.MoveTowards(turretStan.transform.position, standardPos.position, slow);
			camera.transform.position = Vector3.MoveTowards(camera.transform.position, standardcamPos.position, slow);

		}
		if(current == 1){

			tankWheels.transform.position = Vector3.MoveTowards(tankWheels.transform.position, target.position, step);
			tankStandard.transform.position = Vector3.MoveTowards(tankStandard.transform.position, target2.position, step);
			turretStan.transform.position = Vector3.MoveTowards(turretStan.transform.position, wheelPos.position, slow);
			camera.transform.position = Vector3.MoveTowards(camera.transform.position, wheelcamPos.position, slow);

		}
		if (current == 0 && currentturret == 0) {

			//turretStan.transform.position = Vector3.MoveTowards(turretStan.transform.position, standardPos.position, step);
			//turret2.transform.position = Vector3.MoveTowards(turret2.transform.position, targettur2or.position, step);

			turretStan.transform.position = Vector3.MoveTowards(turretStan.transform.position, targettank.position, step);
			turret2.transform.position = Vector3.MoveTowards(turret2.transform.position, targettankcar.position, step);
			turretmort.transform.position = Vector3.MoveTowards(turretmort.transform.position, targettank.position, step);
		}
		if (current == 0 && currentturret == 1) {
			//turretStan.transform.position = Vector3.MoveTowards(turretStan.transform.position, targettur1wheelor.position, step);
			//turret2.transform.position = Vector3.MoveTowards(turret2.transform.position, targettur2stansel.position, step);

			turretStan.transform.position = Vector3.MoveTowards(turretStan.transform.position, targettankcar.position, step);
			turret2.transform.position = Vector3.MoveTowards(turret2.transform.position, targettank.position, step);
			turretmort.transform.position = Vector3.MoveTowards(turretmort.transform.position, targettank.position, step);
		}
		if (current == 1 && currentturret == 0) {

			//turretStan.transform.position = Vector3.MoveTowards(turretStan.transform.position, wheelPos.position, step);
			//turret2.transform.position = Vector3.MoveTowards(turret2.transform.position, targettur2stanor.position, step);

			turretStan.transform.position = Vector3.MoveTowards(turretStan.transform.position, targettankcar.position, step);
			turret2.transform.position = Vector3.MoveTowards(turret2.transform.position, targettank.position, step);
			turretmort.transform.position = Vector3.MoveTowards(turretmort.transform.position, targettank.position, step);
		}
		if (current == 1 && currentturret == 1) {
			//turretStan.transform.position = Vector3.MoveTowards(turretStan.transform.position, targettur1stanor.position, step);
			//turret2.transform.position = Vector3.MoveTowards(turret2.transform.position, targettur2wheelsel.position, step);

			turretStan.transform.position = Vector3.MoveTowards(turretStan.transform.position, targettank.position, step);
			turret2.transform.position = Vector3.MoveTowards(turret2.transform.position, targettankcar.position, step);
			turretmort.transform.position = Vector3.MoveTowards(turretmort.transform.position, targettank.position, step);
		}
		if (current == 0 && currentturret == 2) {
			turretmort.transform.position = Vector3.MoveTowards(turretmort.transform.position, targetmorstansel.position, step);
			turretStan.transform.position = Vector3.MoveTowards (turretStan.transform.position, targettank.position, step);
			turret2.transform.position = Vector3.MoveTowards (turret2.transform.position, targettank.position, step);
		}
		if (current == 1 && currentturret == 2) {
			turretmort.transform.position = Vector3.MoveTowards(turretmort.transform.position, targetmorwheelsel.position, step);
			turretStan.transform.position = Vector3.MoveTowards(turretStan.transform.position, targettank.position, step);
			turret2.transform.position = Vector3.MoveTowards(turret2.transform.position, targettank.position, step);
		}






	}
}