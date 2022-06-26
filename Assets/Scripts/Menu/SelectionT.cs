using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionT : MonoBehaviour {
	public int savetank;
	public int savetur;
	public GameObject rotator;


	void Start () {

	}
	void Awake(){

	}

	void Update () {

	}
	public void StartScene1(){
		savetank = rotator.GetComponent<NEWNEWRotate> ().seltank;
		savetur = rotator.GetComponent<NEWNEWRotate> ().seltur;
		PlayerPrefs.SetInt ("tank", savetank);
		PlayerPrefs.SetInt ("turret", savetur);
		SceneManager.LoadScene ("Basck");
	}
}
