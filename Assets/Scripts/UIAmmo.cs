using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAmmo : MonoBehaviour {
	public GameObject tank;
	private GameObject cannon;
	private int spec;
	private int mag;
	public TextMeshProUGUI ammoText;
	void Start () {

	}

	void Update () {

		cannon = GameObject.FindGameObjectWithTag ("Cannon");
		if (cannon.GetComponent<Cannon> () != null) {
			spec = cannon.GetComponent<Cannon> ().maxAmmoSpecial;
			mag = cannon.GetComponent<Cannon> ().curMag;
		}
		if (cannon.GetComponent<CannonVel> () != null) {
			spec = cannon.GetComponent<CannonVel> ().maxAmmoSpecial;
			mag = cannon.GetComponent<CannonVel> ().curMag;
		}

		ammoText.text = "<size=50>" + mag.ToString() + " / " + spec.ToString();


	}
}
