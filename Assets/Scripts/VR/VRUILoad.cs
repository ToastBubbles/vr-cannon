using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VRUILoad : MonoBehaviour {
	public TextMeshPro text;
	private string round;
	public GameObject roundReader;
	private int roundInt;

	void Start () {
		
	}
	

	void Update () {
		roundInt = roundReader.GetComponent<VRBulletDeleter> ().current;
		if (roundInt == 1) {
			round = "HE Round";
		}else if(roundInt == 2){
			round = "Forcifier";
		}else if(roundInt == 3){
            round = "Guided Missile";
        }else {
			round = "NONE!";
		}
		text.text = " Loaded:" + "\n\n " + round;
			//" <size=50>Current: " + artillery.ToString() + "</size>\n <size=20>Reserve: " + reserve.ToString() + "</size>\n Attack: " + attack.ToString() + "\n Armor: " + armor.ToString() + "\n Speed: " + speed.ToString() + "\n Turn Speed: " + rotSpeed.ToString();
	}
}
