using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLoad : MonoBehaviour {
	public bool load = false;
	public GameObject pos2;
	private Vector3 startpos;
	bool fx = false;
	float speed;
	public GameObject lcase;
	public GameObject lprojo;
	private bool casecheck = false;
	private bool projocheck = false;
	public Transform p1;
	public Transform p2;
	public GameObject slide;
	private GameObject projo;
	public bool returnP = false;

	void Start(){

		startpos = transform.position;
		StartCoroutine (Fix ());
	}

	void Update(){
		casecheck = lcase.GetComponent<VRLoadDetector> ().caseIn;
		projocheck = lprojo.GetComponent<VRLoadPDet> ().projoIn;
		Debug.Log (fx + ("is fx") + casecheck + ("is case") + projocheck + ("is Projo"));
		speed = (2 * Time.deltaTime);
		if (load == true) {
			slide.transform.position = Vector3.Lerp (slide.transform.position, p2.position, speed);
			projo.transform.position = Vector3.Lerp (projo.transform.position, p2.position, speed);
		}
		if (returnP == true) {
			slide.transform.position = Vector3.Lerp (slide.transform.position, p1.position, speed);
		}
	}
	void OnTriggerEnter(Collider other){
		if (fx == true && casecheck == true && projocheck == true) {
			load = true;
			projo = other.gameObject;
			StartCoroutine (Cool ());
			//fire = false;
		}

	}
	IEnumerator Cool(){
		Up ();
		yield return new WaitForSeconds (2);
		Down ();
		load = false;
		StartCoroutine (Return ());

	}
	IEnumerator Return(){
		returnP = true;
		yield return new WaitForSeconds (2);
		returnP = false;
	}
	void Up(){
		transform.position = Vector3.Lerp(pos2.transform.position, startpos, speed);
	}

	void Down(){
		transform.position = Vector3.Lerp(startpos, pos2.transform.position, speed);
	}
	IEnumerator Fix(){
		yield return new WaitForSeconds (1);
		fx = true;
	}

}