using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonVel : MonoBehaviour {

	public int selected;
	public GameObject self;
	public GameObject cone;
	public GameObject forcer;
	private GameObject ammoTracker;
	public ParticleSystem flash;
	public ParticleSystem flashR;
	public Rigidbody projo1;
	public Rigidbody projoGrav;
	public Rigidbody projoCube;
	public Rigidbody projoShield;
	public Rigidbody projoDirt;
	public Rigidbody projoGrenade;
	public Rigidbody projoMachineGun;
	public Transform activePos;
	public Transform posCan;
	public Transform posCanR;
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
	bool toggletur = false;

	public int[] specbull = new int[4];

	private float vel;
	public GameObject holder;



	//Transform posCan1 = posCan.Rotate + (10,0,0);

	void Start () {
		activePos = posCan;
		selected = PlayerPrefs.GetInt("turret");
		ammoTracker = GameObject.FindGameObjectWithTag ("AmmoTracker");
		cur = 1;
		maxAmmoSpecial = 0;
		curMag = 0;
		specbull [0] = 1;
		vel = holder.GetComponent<VelocityControl> ().velocity;


	}
	IEnumerator Cooldown(){
		int vartime;
		if (selected != 1) {
			vartime = 3;
		} else {
			vartime = 2;
		}
		ammoTracker.GetComponent<UIAmmoController> ().isfillT = true;
		counter = 0;
		yield return new WaitForSeconds (vartime);
		ammoTracker.GetComponent<UIAmmoController> ().isfillT = false;
		counter = 1;
	}
	IEnumerator Forcifier(){

		yield return new WaitForSeconds (3);
		Destroy (cone);
	}
	IEnumerator MGCooldown(){
		yield return new WaitForSeconds (1);
		shootcounter = 0;
	}
	IEnumerator MachineGun(){
		Rigidbody bulletMachineGun;
		bulletMachineGun = Instantiate (projoMachineGun, posCan.position, posCan.rotation) as Rigidbody;
		bulletMachineGun.velocity = posCan.forward * vel;
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



	void Update () {
		if (toggletur == false) {
			activePos = posCan;
		} else {
			activePos = posCanR;
		}
		if (lcounter == 1 && curMag == 0 && maxAmmoSpecial > 0) {
			curMag++;
			maxAmmoSpecial--;
		}
	}
	private void LateUpdate(){
		if (Input.GetKeyDown ("e")) {
			if (curselchange == false) {
				curselchange = true;

			} else {
				curselchange = false;

			}
		}
		if (curselchange == true) {
			cur = 1;
		} else {
			cur = specbull [0];
		}

		if (Input.GetKeyDown ("m")) {
			specbull [0] = Random.Range (2, 10);
		}
		if(Input.GetKeyDown("1")){
			cur = 3;
			if (maxAmmoSpecial < 5) {
				maxAmmoSpecial++;
			}
		}
		if(Input.GetKeyDown("2")){
			cur = 4;
			if (maxAmmoSpecial < 5) {
				maxAmmoSpecial++;
			}
		}
		if(Input.GetKeyDown("3")){
			cur = 5;
			if (maxAmmoSpecial < 5) {
				maxAmmoSpecial++;
			}
		}
		if(Input.GetKeyDown("4")){
			cur = 6;
			if (maxAmmoSpecial < 5) {
				maxAmmoSpecial++;
			}
		}
		if(Input.GetKeyDown("5")){
			cur = 7;
			if (maxAmmoSpecial < 5) {
				maxAmmoSpecial++;
			}
		}
		if(Input.GetKeyDown("6")){
			cur = 8;
			if (maxAmmoSpecial < 5) {
				maxAmmoSpecial++;
			}
		}
		if(Input.GetKeyDown("7")){
			cur = 9;
			if (maxAmmoSpecial < 5) {
				maxAmmoSpecial++;
			}
		}

		if (Input.GetMouseButtonDown (0) && counter == 1) {
			if (cur == 1) {
				toggletur = !toggletur;
				Rigidbody bullet;
				bullet = Instantiate (projo1, activePos.position, posCan.rotation) as Rigidbody;
				//bullet.AddForce (posCan.forward * forceAmount);
				bullet.velocity = posCan.forward * vel;
				if (toggletur == true) {
					flash.Emit (50);
				} else {
					flashR.Emit (50);
				}
				StartCoroutine (Cooldown ());
			}
		}
		if (Input.GetMouseButtonDown(0) && cur == 2 && lcounter == 1 && curMag > 0) {
			curMag--;
			Rigidbody bullet;
			bullet = Instantiate (projo1, posCan.position, posCan.rotation) as Rigidbody;
			//bullet.AddForce (posCan.forward * forceAmount);
			bullet.velocity = posCan.forward * vel;
			bullet = Instantiate (projo1, posCan2.position, posCan2.rotation) as Rigidbody;
			//bullet.AddForce (posCan2.forward * forceAmount);
			bullet.velocity = posCan2.forward * vel;
			bullet = Instantiate (projo1, posCan3.position, posCan2.rotation) as Rigidbody;
			//bullet.AddForce (posCan3.forward * forceAmount);
			bullet.velocity = posCan3.forward * vel;
			flash.Emit(50);
			StartCoroutine (LongCooldown ());

			}

		if (Input.GetMouseButtonDown (0) && cur == 3 && lcounter == 1 && curMag > 0) {
			maxAmmoSpecial--;
			Rigidbody bulletGrav;
			bulletGrav = Instantiate (projoGrav, posCan.position, posCan.rotation) as Rigidbody;
			bulletGrav.velocity = posCan.forward * vel;
			flash.Emit (50);
			StartCoroutine (LongCooldown ());
		}
		if (Input.GetMouseButtonDown (0) && cur == 4 && lcounter == 1 && curMag > 0) {
			curMag--;
			Rigidbody bulletCube;
			bulletCube = Instantiate (projoCube, posCan.position, posCan.rotation) as Rigidbody;
			bulletCube.velocity = posCan.forward * vel;
			flash.Emit (50);
			StartCoroutine (LongCooldown ());
		}
		if (Input.GetMouseButton (0) && cur == 5 && counter == 1 && curMag > 0) {
			curMag--;
			//GameObject cone;
			cone = Instantiate (forcer, posCan.position, posCan.rotation) as GameObject;
			cone.transform.SetParent (posCan);
//			detector = 1;
			StartCoroutine (Forcifier());
			StartCoroutine (Cooldown ());
		}
//		} else if (Input.GetMouseButtonUp (0) && detector == 1) {
//			//forcer.GetComponent<ForcifierDestroyer> ().remover = true;
//			//forcer.GetComponent<ForcifierDestroyer> ().Die();
//			Destroy(cone);
//			Debug.Log ("mouseUP");
//			detector = 0;
//		}
		if (Input.GetMouseButtonDown (0) && cur == 6 && lcounter == 1 && curMag > 0) {
			curMag--;
			Rigidbody bulletShield;
			bulletShield = Instantiate (projoShield, posCan.position, posCan.rotation) as Rigidbody;
			bulletShield.velocity = posCan.forward * vel;
			flash.Emit (50);
			StartCoroutine (LongCooldown ());
		}
		if (Input.GetMouseButtonDown (0) && cur == 7 && lcounter == 1 && curMag > 0) {
			curMag--;
			Rigidbody bulletDirt;
			bulletDirt = Instantiate (projoDirt, posCan.position, posCan.rotation) as Rigidbody;
			bulletDirt.velocity = posCan.forward * vel;
			flash.Emit (50);
			StartCoroutine (LongCooldown ());
		}
		if (Input.GetMouseButtonDown (0) && cur == 8 && lcounter == 1 && curMag > 0) {
			curMag--;
			Rigidbody bulletGrenade;
			bulletGrenade = Instantiate (projoGrenade, posCan.position, posCan.rotation) as Rigidbody;
			bulletGrenade.velocity = posCan.forward * vel;
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
