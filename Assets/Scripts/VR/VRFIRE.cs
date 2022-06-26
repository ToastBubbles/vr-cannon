using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRFIRE : MonoBehaviour {
	public bool fire = false;
	public GameObject pos2;
	private Vector3 startpos;
	bool fx = false;
	float speed;

	void Start(){
		startpos = transform.position;
		StartCoroutine (Fix ());
	}

	void Update(){
		speed = (2 * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other){
		if (fx == true) {
			fire = true;
			StartCoroutine (Cool ());
		}

	}
	IEnumerator Cool(){
		Up ();
		yield return new WaitForSeconds (0.2f);
		Down ();
		fire = false;
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
