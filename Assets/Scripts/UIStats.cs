using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStats : MonoBehaviour {
	public GameObject tank;
	private GameObject cannon;
	private int ammo;
	private int specbull;
	private int attack;
	private int armor;
	private int speed;
	private int rotSpeed;
	private bool check;
	public int anum;

	public string artillery;
	public string reserve;
	public TextMeshProUGUI speedText;
	void Start () {
		cannon = GameObject.FindGameObjectWithTag ("Cannon");
	}

	void Update () {
		ArtilleryReader ();
		if (cannon.GetComponent<Cannon> () != null) {
			ammo = cannon.GetComponent<Cannon> ().maxAmmoSpecial;
		}
		if (cannon.GetComponent<CannonVel> () != null) {
			ammo = cannon.GetComponent<CannonVel> ().maxAmmoSpecial;
		}

		attack = tank.GetComponent<Stats> ().curattack;
		armor = tank.GetComponent<Stats> ().curarmor;
		speed = tank.GetComponent<Stats> ().curspeed;
		rotSpeed = tank.GetComponent<Stats> ().currotSpeed;
		speedText.text = " <size=50>Current: " + artillery.ToString() + "</size>\n <size=20>Reserve: " + reserve.ToString() + "</size>\n Attack: " + attack.ToString() + "\n Armor: " + armor.ToString() + "\n Speed: " + speed.ToString() + "\n Turn Speed: " + rotSpeed.ToString();

	}
	public void ArtilleryReader(){
		if(cannon.GetComponent<Cannon> () != null){
		check = cannon.GetComponent<Cannon> ().curselchange;
		anum = cannon.GetComponent<Cannon> ().cur;
		specbull = cannon.GetComponent<Cannon> ().specbull[0];
		}
		if(cannon.GetComponent<CannonVel> () != null){
		check = cannon.GetComponent<CannonVel> ().curselchange;
		anum = cannon.GetComponent<CannonVel> ().cur;
		specbull = cannon.GetComponent<CannonVel> ().specbull[0];
		}
		if (anum == 0) {
			artillery = ("None!");
		}else if (anum == 1) {
			artillery = ("Single");
		} else if (anum == 2) {
			artillery = ("Triple");
		}
		else if (anum == 3) {
			artillery = ("Gravity Modulator");
		}
		else if (anum == 4) {
			artillery = ("Cubifier");
		}
		else if (anum == 5) {
			artillery = ("Forcifier");
		}
		else if (anum == 6) {
			artillery = ("Protect-a-tank");
		}
		else if (anum == 7) {
			artillery = ("Dirty Bomb");
		}
		else if (anum == 8) {
			artillery = ("Grenade");
		}
		else if (anum == 9) {
			artillery = ("Machine Gun");
		}
		if (specbull <= 1) {
			reserve = ("None");
		} else if (specbull == 2 && check == true) {
			reserve = ("Triple");
		} else if (specbull == 3 && check == true) {
			reserve = ("Gravity Modulator");
		} else if (specbull == 4 && check == true) {
			reserve = ("Cubifier");
		} else if (specbull == 5 && check == true) {
			reserve = ("Forcifier");
		} else if (specbull == 6 && check == true) {
			reserve = ("Protect-a-Tank");
		} else if (specbull == 7 && check == true) {
			reserve = ("Dirty Bomb");
		} else if (specbull == 8 && check == true) {
			reserve = ("Grenade");
		} else if (specbull == 9 && check == true) {
			reserve = ("Machine Gun");
		} else {
			reserve = ("Single");
		}
	}
}
