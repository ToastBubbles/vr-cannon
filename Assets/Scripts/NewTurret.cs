using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTurret : MonoBehaviour {
	public float rotSpeed = 5.0f;
	public float rotSpeedBarrel = 5.0f;
	public float maxBarrelUp = 70f;
	public float maxBarrelDown = -5f;
	//float counter = 0f;
	public GameObject barrel;


	void Start () {
		
	}
	

	void FixedUpdate () {
		//var scroll = Input.GetAxis("Mouse ScrollWheel");
		//float vel = rotSpeed * Time.deltaTime;
		//if(Input.GetKey("q")){
		//	transform.Rotate (0, 0, -rotSpeed);
		//}
		//if(Input.GetKey("e")){
		//	transform.Rotate (0, 0, rotSpeed);
		//	}
		//if(scroll > 0f && counter < maxBarrelUp){
		//	barrel.transform.Rotate (-rotSpeedBarrel, 0, 0);
		//	counter += rotSpeedBarrel;
		//}
		//if(scroll < 0f && counter > maxBarrelDown){
		//	barrel.transform.Rotate (rotSpeedBarrel, 0, 0);
		//	counter -= rotSpeedBarrel;
		//}
			
	}
}
