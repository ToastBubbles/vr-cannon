using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankChanger : MonoBehaviour {
	public GameObject tank;
	public GameObject tankCar;
	private bool checker = true;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("t") && checker == true){
			tank.SetActive(false);
			tankCar.SetActive(true);
			checker = false;
		}else if (Input.GetKeyDown("t") && checker == false){
			tank.SetActive(true);
			tankCar.SetActive(false);
			checker = true;
		}
}
}
