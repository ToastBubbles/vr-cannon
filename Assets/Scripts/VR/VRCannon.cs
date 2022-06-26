using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCannon : MonoBehaviour {

	public GameObject self;
	private GameObject cone;
	public GameObject forcer;
	private GameObject ammoTracker;
	public ParticleSystem flash;
	public Rigidbody projo1;
	public Rigidbody projoGrav;
	public Rigidbody projoCube;
	public Rigidbody projoShield;
	public Rigidbody projoDirt;
	public Rigidbody projoGrenade;
	public Rigidbody projoMachineGun;
	public Transform posCan;
	public Transform posCan2;
	public Transform posCan3;
	public float forceAmount;
	public float forceGravAmount;
	public float forceGrenadeAmount;
	public int cur;
	public int curMag;
	public int maxReserve;
	public int maxAmmoSpecial;
	public int cursel;
	public bool curselchange = false;
	float counter = 1;
	float forcecheck = 1;
	int lcounter = 1;
	float detector = 0;
	int shootcounter = 0;
	bool istrue = false;
	public GameObject fireButton;
	bool fire;
	public GameObject roundReader;
	private int curRound;

	public int[] specbull = new int[4];
	//Transform posCan1 = posCan.Rotate + (10,0,0);

	void Start () {
		roundReader = GameObject.FindGameObjectWithTag ("RoundReader");
		//ammoTracker = GameObject.FindGameObjectWithTag ("AmmoTracker");
		//cur = 1;
		//maxAmmoSpecial = 0;
		//curMag = 0;
		//specbull [0] = 1;


	}
	IEnumerator Cooldown(){
		//ammoTracker.GetComponent<UIAmmoController> ().isfillT = true;
		counter = 0;
		yield return new WaitForSeconds (3);
		//ammoTracker.GetComponent<UIAmmoController> ().isfillT = false;
		counter = 1;
	}
	IEnumerator Forcifier(){

		yield return new WaitForSeconds (5);
		Destroy (cone);

	}
	IEnumerator MGCooldown(){
		yield return new WaitForSeconds (1);
		shootcounter = 0;
	}
	IEnumerator MachineGun(){
		Rigidbody bulletMachineGun;
		bulletMachineGun = Instantiate (projoMachineGun, posCan.position, posCan.rotation) as Rigidbody;
		bulletMachineGun.AddForce (posCan.forward * forceAmount);
		//Shooter ();
		//istrue = true;

		yield return new WaitForSeconds(.1f);
		//istrue = false;
		if (shootcounter < 10) {
			shootcounter++;
			StartCoroutine (MachineGun ());
		}
		Debug.Log (shootcounter);
	}
	IEnumerator LongCooldown(){
		lcounter = 0;
		ammoTracker.GetComponent<UIAmmoController> ().isfillB = true;

		yield return new WaitForSeconds (7);
		ammoTracker.GetComponent<UIAmmoController> ().isfillB = false;
		lcounter = 1;
		if (maxAmmoSpecial > 0) {
			curMag++;
			maxAmmoSpecial--;

		}

	}
	void Reset(){
		roundReader.GetComponent<VRBulletDeleter> ().current = 0;
	}


	void Update () {
		curRound = roundReader.GetComponent<VRBulletDeleter> ().current;
		fireButton = GameObject.FindGameObjectWithTag ("ButtonCol");
		fire = fireButton.GetComponent<VRFIRE> ().fire;
	}

	private void LateUpdate(){

		//Fire HE Round//
		if (fire == true) {
			if (curRound == 1) {
				Rigidbody bullet;
				bullet = Instantiate (projo1, posCan.position, posCan.rotation) as Rigidbody;
				bullet.AddForce (posCan.forward * forceAmount);
				flash.Emit (50);
				Reset ();
				//StartCoroutine (Cooldown ());
			}
		}
		if (Input.GetMouseButtonDown(0) && cur == 2 && lcounter == 1 && curMag > 0) {
			curMag--;
			Rigidbody bullet;
			bullet = Instantiate (projo1, posCan.position, posCan.rotation) as Rigidbody;
			bullet.AddForce (posCan.forward * forceAmount);
			bullet = Instantiate (projo1, posCan2.position, posCan2.rotation) as Rigidbody;
			bullet.AddForce (posCan2.forward * forceAmount);
			bullet = Instantiate (projo1, posCan3.position, posCan2.rotation) as Rigidbody;
			bullet.AddForce (posCan3.forward * forceAmount);
			flash.Emit(50);
			StartCoroutine (LongCooldown ());
			}

		if (Input.GetMouseButtonDown (0) && cur == 3 && lcounter == 1 && curMag > 0) {
			maxAmmoSpecial--;
			Rigidbody bulletGrav;
			bulletGrav = Instantiate (projoGrav, posCan.position, posCan.rotation) as Rigidbody;
			bulletGrav.AddForce (posCan.forward * forceGravAmount);
			flash.Emit (50);
			StartCoroutine (LongCooldown ());
		}
		if (Input.GetMouseButtonDown (0) && cur == 4 && lcounter == 1 && curMag > 0) {
			curMag--;
			Rigidbody bulletCube;
			bulletCube = Instantiate (projoCube, posCan.position, posCan.rotation) as Rigidbody;
			bulletCube.AddForce (posCan.forward * forceGravAmount);
			flash.Emit (50);
			StartCoroutine (LongCooldown ());
		}
		//Activate Forcer//
		if (fire == true && curRound == 2) {
			cone = Instantiate (forcer, posCan.position, posCan.rotation) as GameObject;
			cone.transform.SetParent (posCan);
			Reset ();
			StartCoroutine (Forcifier());
			StartCoroutine (Cooldown ());
		}

		if (Input.GetMouseButtonDown (0) && cur == 6 && lcounter == 1 && curMag > 0) {
			curMag--;
			Rigidbody bulletShield;
			bulletShield = Instantiate (projoShield, posCan.position, posCan.rotation) as Rigidbody;
			bulletShield.AddForce (posCan.forward * forceGravAmount);
			flash.Emit (50);
			StartCoroutine (LongCooldown ());
		}
		if (Input.GetMouseButtonDown (0) && cur == 7 && lcounter == 1 && curMag > 0) {
			curMag--;
			Rigidbody bulletDirt;
			bulletDirt = Instantiate (projoDirt, posCan.position, posCan.rotation) as Rigidbody;
			bulletDirt.AddForce (posCan.forward * forceGravAmount);
			flash.Emit (50);
			StartCoroutine (LongCooldown ());
		}
		if (Input.GetMouseButtonDown (0) && cur == 8 && lcounter == 1 && curMag > 0) {
			curMag--;
			Rigidbody bulletGrenade;
			bulletGrenade = Instantiate (projoGrenade, posCan.position, posCan.rotation) as Rigidbody;
			bulletGrenade.AddForce (posCan.forward * forceGrenadeAmount);
			flash.Emit (50);
			StartCoroutine (LongCooldown ());
		}

		if (shootcounter == 10) {
			StartCoroutine (MGCooldown ());
		}
		if (Input.GetMouseButtonDown (0) && cur == 9 && lcounter == 1 && curMag > 0) {
			StartCoroutine (MachineGun ());
			curMag--;
			flash.Emit (50);
			StartCoroutine (LongCooldown ());
		}



		}
}
