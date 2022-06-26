using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTurret : MonoBehaviour {
	float getClick = 0f;
	public GameObject turret;
	void Start (){
		Debug.Log (getClick);
	}

	public void FixedUpdate(){
		if (getClick == 1f) {
			Debug.Log (getClick);
			GetSavedColor ();
		}
	}

	public void GetSavedColor()
	{
		Color GetedColor=  HexToColor(PlayerPrefs.GetString("SavedTurretColor"));
		getClick = 0f;
		Debug.Log (PlayerPrefs.GetString ("SavedTurretColor"));
		Debug.Log (getClick);
		turret.GetComponent<Renderer> ().material.color = GetedColor;
	}
	// Note that Color32 and Color implictly convert to each other. You may pass a Color object to this method without first casting it.


	Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r,g,b, 255);
	}
}
