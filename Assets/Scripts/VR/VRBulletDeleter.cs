using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRBulletDeleter : MonoBehaviour {
	private bool del = false;
	public int current = 0; 
	//load bullet
	//delete bullet
	void Start () {
		
	}
	

	void Update () {
		if (current == 1) {
			Debug.Log ("HE Loaded");
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.name == ("HEProjo")){
			current = 1;
		}
		if (other.name == ("Forcer")){
			current = 2;
		}
        if (other.name == ("GM"))
        {
            current = 3;
        }
		if (other.tag == ("Shell")) {
			StartCoroutine (Delete ());
			//if (del == true) {
				Destroy (other.gameObject);
				del = false;
			//}
		}
	}

	IEnumerator Delete(){
		del = false;
		yield return new WaitForSeconds (0.5f);
		del = true;
	}
}
