using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCastMortar : MonoBehaviour {

	LineRenderer lr;

	private float height;
	public float rot;
	public GameObject turretX;
	public GameObject bulletpoint;
	public GameObject body;
	private float turx;
	private float turcor;
	private float leftr;
	private float mag;

	public float vel = 20;
	private float angle = 100;
	public int res = 10;

	float g;
	float radAngle;

	void Awake(){
		lr = GetComponent<LineRenderer> ();
		g = Mathf.Abs (Physics2D.gravity.y);


	}

	void Start(){
		//height = //position.y
		RenderArc ();


	}
	void Update(){
		rot = turretX.transform.eulerAngles.y;
		Vector3 srt = new Vector3 (vel, height, rot);
		mag = Vector3.Magnitude (srt);
		turx = turretX.transform.eulerAngles.x;
		height = bulletpoint.transform.position.y;
		turcor = turx - 180;
		angle = turcor;
		RenderArc ();

		//Debug.Log (angle+ "is angle");

	}

	void RenderArc(){
		lr.SetVertexCount (res + 1);
		lr.SetPositions (CalcArcArray ());

	}

	Vector3[] CalcArcArray(){
		Vector3[] arcArray = new Vector3[res + 1];

		radAngle = Mathf.Deg2Rad * angle;
		float maxDist = (vel * vel * Mathf.Sin (2 * radAngle)) / g;

		for (int i = 0; i <= res; i++) {
			float t = (float)i / (float)res;
			arcArray [i] = CalcArcPoint (t, maxDist);
		}
		return arcArray;
	}

	//calc height/dist
	Vector3 CalcArcPoint(float t, float maxDist){
		float x = t * maxDist;
		float y = height + x * Mathf.Tan (radAngle) - ((g * x * x) / (2 * vel * vel * Mathf.Cos (radAngle) * Mathf.Cos (radAngle)));
		float z = body.transform.rotation.y;
		return new Vector3 (x, y, z);
	}

}