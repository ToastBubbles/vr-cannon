﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDriver : MonoBehaviour {



	public GameObject wheelCollider; 
	public float wheelRadius = 0.15f; 
	public float suspensionOffset = 0.05f; 
	public float trackTextureSpeed = 2.5f; 
	public GameObject leftTrack; 
	public Transform[] leftTrackUpperWheels; 
	public Transform[] leftTrackWheels; 
	public Transform[] leftTrackBones; 
	public GameObject rightTrack; 
	public Transform[] rightTrackUpperWheels;
	public Transform[] rightTrackWheels; 
	public Transform[] rightTrackBones; 
	public class WheelData { 
		public Transform wheelTransform; 
		public Transform boneTransform; 
		public WheelCollider col; 
		public Vector3 wheelStartPos; 
		public Vector3 boneStartPos; 
		public float rotation = 0.0f; 
		public Quaternion startWheelAngle; 
	} 
	protected WheelData[] leftTrackWheelData; 
	protected WheelData[] rightTrackWheelData; 
	protected float leftTrackTextureOffset = 0.0f; 
	protected float rightTrackTextureOffset = 0.0f;

	public float rotateOnStandTorque = 1500.0f; 
	public float rotateOnStandBrakeTorque = 500.0f;
	public float maxBrakeTorque = 1000.0f;

	void Awake() { 
		leftTrackWheelData = new WheelData[leftTrackWheels.Length]; 
		rightTrackWheelData = new WheelData[rightTrackWheels.Length]; 
		for(int i=(0);i<leftTrackWheels.Length;i++){ 
			leftTrackWheelData[i] = SetupWheels(leftTrackWheels[i],leftTrackBones[i]); 
		} 
		for(int i=0;i<rightTrackWheels.Length;i++){
			rightTrackWheelData[i] = SetupWheels(rightTrackWheels[i],rightTrackBones[i]);
		}
		Vector3 offset = transform.position;
		offset.z +=0.01f; 
		transform.position = offset; 
	}
	WheelData SetupWheels(Transform wheel, Transform bone){ 
		WheelData result = new WheelData();
		GameObject go = new GameObject("Collider_"+wheel.name); 
		go.transform.parent = transform; 
		go.transform.position = wheel.position; 
		go.transform.localRotation = Quaternion.Euler(45,45,45); 
		WheelCollider col = (WheelCollider) go.AddComponent(typeof(WheelCollider));
		WheelCollider colPref = wheelCollider.GetComponent<WheelCollider>();
		col.mass = colPref.mass;
		col.center = colPref.center;
		col.radius = colPref.radius;
		col.suspensionDistance = colPref.suspensionDistance;
		col.suspensionSpring = colPref.suspensionSpring;
		col.forwardFriction = colPref.forwardFriction;
		col.sidewaysFriction = colPref.sidewaysFriction;
		result.wheelTransform = wheel; 
		result.boneTransform = bone; 
		result.col = col; 
		result.wheelStartPos = wheel.transform.localPosition;
		result.boneStartPos = bone.transform.localPosition;
		result.startWheelAngle = wheel.transform.localRotation;
		return result; 
	}

	void FixedUpdate(){ 
		UpdateWheels(); 
		float accelerate = 0; 
		float steer = 0; 
		accelerate = Input.GetAxis("Vertical"); 
		steer = Input.GetAxis("Horizontal"); 
		UpdateWheels(accelerate,steer); 
	} 
	public void UpdateWheels(){ 
		float delta = Time.fixedDeltaTime; 
		float trackRpm = CalculateSmoothRpm(leftTrackWheelData);
		foreach (WheelData w in leftTrackWheelData){ 
			w.wheelTransform.localPosition = CalculateWheelPosition(w.wheelTransform,w.col,w.wheelStartPos); 
			w.boneTransform.localPosition = CalculateWheelPosition(w.boneTransform,w.col,w.boneStartPos); 
			w.rotation = Mathf.Repeat(w.rotation + delta * trackRpm * 360.0f / 60.0f, 360.0f); 
			w.wheelTransform.localRotation = Quaternion.Euler(w.rotation, w.startWheelAngle.y, w.startWheelAngle.z); 
		} 
		leftTrackTextureOffset = Mathf.Repeat(leftTrackTextureOffset + delta*trackRpm*trackTextureSpeed/60.0f,1.0f); 
		leftTrack.GetComponent<Renderer>().material.SetTextureOffset("_MainTex",new Vector2(0,-leftTrackTextureOffset)); 
		trackRpm = CalculateSmoothRpm(rightTrackWheelData); 
		foreach (WheelData w in rightTrackWheelData){ 
			w.wheelTransform.localPosition = CalculateWheelPosition(w.wheelTransform,w.col,w.wheelStartPos); 
			w.boneTransform.localPosition = CalculateWheelPosition(w.boneTransform,w.col,w.boneStartPos); 
			w.rotation = Mathf.Repeat(w.rotation + delta * trackRpm * 360.0f / 60.0f, 360.0f); 
			w.wheelTransform.localRotation = Quaternion.Euler(w.rotation, w.startWheelAngle.y, w.startWheelAngle.z); 
		} 
		rightTrackTextureOffset = Mathf.Repeat(rightTrackTextureOffset + delta*trackRpm*trackTextureSpeed/60.0f,1.0f);
		rightTrack.GetComponent<Renderer>().material.SetTextureOffset("_MainTex",new Vector2(0,-rightTrackTextureOffset)); 
		for(int i=0;i<leftTrackUpperWheels.Length;i++){ 
			leftTrackUpperWheels[i].localRotation = Quaternion.Euler(leftTrackWheelData[0].rotation, leftTrackWheelData[0].startWheelAngle.y, leftTrackWheelData[0].startWheelAngle.z); 
		} 
		for(int i=0;i<rightTrackUpperWheels.Length;i++){ 
			rightTrackUpperWheels[i].localRotation = Quaternion.Euler(rightTrackWheelData[0].rotation, rightTrackWheelData[0].startWheelAngle.y, rightTrackWheelData[0].startWheelAngle.z); 
		} 
	} 
	private float CalculateSmoothRpm(WheelData[] w){ 
		float rpm = 0.0f; List<int> grWheelsInd = new List<int>(); 
		for(int i = 0;i<w.Length;i++){ 
			if(w[i].col.isGrounded){ 
				grWheelsInd.Add(i); 
			} 
		} 
		if(grWheelsInd.Count == 0){ 
			foreach(WheelData wd in w){ 
				rpm +=wd.col.rpm; 
			} rpm /= w.Length; 
		}else{ 
			for(int i = 0;i<grWheelsInd.Count;i++){ 
				rpm +=w[grWheelsInd[i]].col.rpm; 
			}
			rpm /= grWheelsInd.Count;
		} return rpm; 
	} 
	private Vector3 CalculateWheelPosition(Transform w,WheelCollider col,Vector3 startPos){ 
		WheelHit hit; Vector3 lp = w.localPosition; 
		if (col.GetGroundHit(out hit)) { 
		lp.y -= Vector3.Dot(w.position - hit.point, transform.up) - wheelRadius; 
		}else { 
			lp.y = startPos.y - suspensionOffset; 
		} 
		return lp; 
	}
	//
	//public float rotateOnStandTorque = 1500.0f; 
	//public float rotateOnStandBrakeTorque = 500.0f;
	//public float maxBrakeTorque = 1000.0f;
	//void FixedUpdate(){ 
		//float accelerate = 0; 
		//float steer = 0; 
		//accelerate = Input.GetAxis("Vertical"); 
		//steer = Input.GetAxis("Horizontal"); 
		//UpdateWheels(accelerate,steer); 
	//}
	public void UpdateWheels(float accel,float steer){
		
		float delta = Time.fixedDeltaTime; float trackRpm = CalculateSmoothRpm(leftTrackWheelData); 
		foreach (WheelData w in leftTrackWheelData){ 
			w.wheelTransform.localPosition = CalculateWheelPosition(w.wheelTransform,w.col,w.wheelStartPos); 
			w.boneTransform.localPosition = CalculateWheelPosition(w.boneTransform,w.col,w.boneStartPos); 
			w.rotation = Mathf.Repeat(w.rotation + delta * trackRpm * 360.0f / 60.0f, 360.0f); 
			w.wheelTransform.localRotation = Quaternion.Euler(w.rotation, w.startWheelAngle.y, w.startWheelAngle.z); 
			CalculateMotorForce(w.col,accel,steer); 
		}
		leftTrackTextureOffset = Mathf.Repeat(leftTrackTextureOffset + delta*trackRpm*trackTextureSpeed/60.0f,1.0f); 
		leftTrack.GetComponent<Renderer>().material.SetTextureOffset("_MainTex",new Vector2(0,-leftTrackTextureOffset)); 
		trackRpm = CalculateSmoothRpm(rightTrackWheelData); 
		foreach (WheelData w in rightTrackWheelData){
			w.wheelTransform.localPosition = CalculateWheelPosition(w.wheelTransform,w.col,w.wheelStartPos); 
			w.boneTransform.localPosition = CalculateWheelPosition(w.boneTransform,w.col,w.boneStartPos); 
			w.rotation = Mathf.Repeat(w.rotation + delta * trackRpm * 360.0f / 60.0f, 360.0f);
			w.wheelTransform.localRotation = Quaternion.Euler(w.rotation, w.startWheelAngle.y, w.startWheelAngle.z);
			CalculateMotorForce(w.col,accel,-steer); 
		} 
		rightTrackTextureOffset = Mathf.Repeat(rightTrackTextureOffset + delta*trackRpm*trackTextureSpeed/60.0f,1.0f); 
		rightTrack.GetComponent<Renderer>().material.SetTextureOffset("_MainTex",new Vector2(0,-rightTrackTextureOffset)); 
		for(int i=0;i<leftTrackUpperWheels.Length;i++){
			leftTrackUpperWheels[i].localRotation = Quaternion.Euler(leftTrackWheelData[0].rotation, leftTrackWheelData[0].startWheelAngle.y, leftTrackWheelData[0].startWheelAngle.z); 
		}
		for(int i=0;i<rightTrackUpperWheels.Length;i++){
			rightTrackUpperWheels[i].localRotation = Quaternion.Euler(rightTrackWheelData[0].rotation, rightTrackWheelData[0].startWheelAngle.y, rightTrackWheelData[0].startWheelAngle.z);
		}
	} 
	public void CalculateMotorForce(WheelCollider col, float accel, float steer){
		if(accel == 0 && steer == 0){ 
			col.brakeTorque = maxBrakeTorque; 
		}else if(accel == 0.0f){
			col.brakeTorque = rotateOnStandBrakeTorque; 
			col.motorTorque = steer*rotateOnStandTorque; 
		} 
	}





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}