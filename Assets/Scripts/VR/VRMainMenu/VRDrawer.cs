using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRDrawer : MonoBehaviour {
	public GameObject turd;
	public GameObject tankd;
	public GameObject pstank;
	public GameObject pwtank;
	public GameObject pstur;
	public GameObject pdtur;
	public GameObject pmtur;

	private string tank;
	private string tur;

	void Start () {
		
	}
	

	void Update () {
		tank = tankd.GetComponent<VRTankSave> ().curTank;
		tur = turd.GetComponent<VRTurretSave> ().curTur;
		if (tank == "Standard") {
			pstank.SetActive (true);
			pwtank.SetActive (false);
		} else if (tank == "Wheels") {
			pstank.SetActive (false);
			pwtank.SetActive (true);
		} else if (tank == "null") {
			pstank.SetActive (false);
			pwtank.SetActive (false);
		}
		if (tur == "Single") {
			pstur.SetActive (true);
			pdtur.SetActive (false);
			pmtur.SetActive (false);
		} else if (tur == "Dual") {
			pstur.SetActive (false);
			pdtur.SetActive (true);
			pmtur.SetActive (false);
		} else if (tur == "Mortar") {
			pstur.SetActive (false);
			pdtur.SetActive (false);
			pmtur.SetActive (true);
		} else if (tur == "null") {
			pstur.SetActive (false);
			pdtur.SetActive (false);
			pmtur.SetActive (false);
		}
	}
}
