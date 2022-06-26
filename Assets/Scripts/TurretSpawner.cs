using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour {
	public GameObject self;
	public GameObject chassis;
	public GameObject turret;
	public GameObject turretFxr;
	public GameObject turretFxr2;
	public GameObject turretFxrmort;
	public Transform turretPosition;
	public Transform rotFix;
	private int seltur;

	void Start () {
		//reenable for main menu
		//seltur = PlayerPrefs.GetInt("turret");
		seltur = 0;
		Debug.Log (seltur + "is turret");
		if (seltur == 0) {
			GameObject turretSpawned;
			turretSpawned = Instantiate (turretFxr, turretPosition.position, rotFix.rotation) as GameObject;
			turretSpawned.transform.parent = self.transform;
		} else if (seltur == 1) {
			GameObject turretSpawned1;
			turretSpawned1 = Instantiate (turretFxr2, turretPosition.position, rotFix.rotation) as GameObject;
			turretSpawned1.transform.parent = self.transform;
		} else if (seltur == 2) {
			GameObject turretSpawned2;
			turretSpawned2 = Instantiate (turretFxrmort, turretPosition.position, rotFix.rotation) as GameObject;
			turretSpawned2.transform.parent = self.transform;
		}
		ColorLoader ();
	}
	void ColorLoader(){
		Color TankColor=  HexToColor(PlayerPrefs.GetString("SavedTankColor"));
		chassis.GetComponent<Renderer> ().sharedMaterial.color = TankColor;
		Color TurretColor=  HexToColor(PlayerPrefs.GetString("SavedTurretColor"));
		turret.GetComponent<Renderer> ().sharedMaterial.color = TurretColor;
	}
	Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r,g,b, 255);
	}

}
