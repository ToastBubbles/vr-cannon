using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveType : MonoBehaviour {
	public int savetank;
	public int savetur;
	public GameObject rotator;


	void Start () {
		
	}
	void Awake(){

	}

	void Update () {
		savetank = rotator.GetComponent<NEWNEWRotate> ().seltank;
		savetur = rotator.GetComponent<NEWNEWRotate> ().seltur;
		PlayerPrefs.SetInt ("tank", savetank);
		PlayerPrefs.SetInt ("turret", savetur);
	}
}
