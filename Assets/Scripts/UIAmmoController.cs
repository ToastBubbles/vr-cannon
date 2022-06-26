using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmoController : MonoBehaviour {
	public GameObject bottomLoad;
	public GameObject topLoad;
	private Image tL;
	private Image bL;
	private float slowFill;
	public bool isfillT = false;
	public bool isfillB = false;

	void Start () {
		tL = topLoad.GetComponent<Image> ();
		bL = bottomLoad.GetComponent<Image> ();
		tL.fillAmount = 0f;
		bL.fillAmount = 0f;
	}
	

	void Update () {
		//slowFill += 30 * Time.deltaTime;

		if (tL.fillAmount == 1f && isfillT == false) {
			tL.fillAmount = 0f;
		} else if (tL.fillAmount < 1f && isfillT == true) {
			tL.fillAmount += (34 * Time.deltaTime)/100; //slowFill/100;
		}

		if (bL.fillAmount == 1f && isfillB == false) {
			bL.fillAmount = 0f;
		} else if (bL.fillAmount < 1f && isfillB == true) {
			bL.fillAmount += (15 * Time.deltaTime)/100; //slowFill/100;
		}
	}

	public void fillTop(){
		tL.fillAmount += (32 * Time.deltaTime)/100; //slowFill/100;
		if (tL.fillAmount == 1f) {
			tL.fillAmount = 0f;
			return;
		}

	}
	//IEnumerator TopFill(){

	//}

	//IEnumerator BotFill(){

	//}
}
