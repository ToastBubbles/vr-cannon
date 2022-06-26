using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveColorTank : MonoBehaviour {
	float click = 0f;
	public GameObject tank;
	void Start (){
		Debug.Log (click);
	}

	public void IsClicked (){
		click = 1f;
		Debug.Log (click);
	}

	public void FixedUpdate(){
		if (click == 1f) {
			Debug.Log (click);
			SaveColor(tank.GetComponent<Renderer>().material.color);
		}
	}

	public void SaveColor(Color color)
	{
		if (click == 1f) {
			PlayerPrefs.SetString ("SavedTankColor", ColorToHex (color));
			Debug.Log ("tank saved!");
			click = 0f;
			Debug.Log (click);
		}
	}
	string ColorToHex(Color32 color)
	{
		string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
		return hex;
	}


}
