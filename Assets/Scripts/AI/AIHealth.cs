using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIHealth : MonoBehaviour {
	public Transform tankPos;
	public Transform respawnPoint;

	//public GameObject bullet;
	public GameObject tank;
	public GameObject turret;
	public GameObject canPos;
	public GameObject explosion;
	public GameObject charred;
	public GameObject[] respawns;
	public float dmg;
	public float current;
	public float cursh;
	public float hp;
	public float sp;
	public float fullhp;
	public float fullsp;
	public bool once;
	public bool location;
	public GameObject health;
	public GameObject shield;
	public GameObject canvas;




	void Start(){

		fullsp = 100f;
		fullhp = 100f;
		hp = fullhp;
		sp = fullsp;


		once = false;
		location = false;

	}

	void FixedUpdate()
	{
		
		current = hp;
		cursh = sp;
		if (current > 0) {
			health.GetComponent<Image> ().fillAmount = current / 100;
		} else if (current <= 0) {
			health.GetComponent<Image> ().fillAmount = 0f;
		}

		if (cursh > 0) {
			shield.GetComponent<Image> ().fillAmount = current / 100;
		} else if (cursh <= 0) {
			shield.GetComponent<Image> ().fillAmount = 0f;
		}

		Debug.Log("AI Health : " + hp + " AI Damage taken: " + dmg + " AI current: " + current + " AI current shield: " + cursh);

		if (current <= 0f) {
			StartCoroutine (Respawn ());
			Debug.Log ("died");
		}
	}
	public void DMG (){
		if (sp >= 0) {
			cursh = (sp -= dmg);
		} else {
			current = (hp -= dmg);
		}
		Debug.Log ("AI: " + current);
		return;
	}
	IEnumerator Respawn (){

		//canvas.SetActive (false);

		var renderers = tank.GetComponentsInChildren<Renderer> ();
		foreach (var renderer in renderers)
			renderer.enabled = false;
		var colliders = tank.GetComponentsInChildren<Collider> ();
		foreach (var collider in colliders)
			collider.enabled = false;

		tank.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;

		if (once == false) {
			GameObject explode;
			explode = Instantiate (explosion, tankPos.position, tankPos.rotation);
			GameObject corpse;
			corpse = Instantiate (charred, tankPos.position, tankPos.rotation);
			once = true;
		}


		yield return new WaitForSeconds (3);

		hp = fullhp;
		sp = fullsp;
		if (location == false) {
			tankPos.transform.position = respawnPoint.transform.position;
			tankPos.transform.rotation = respawnPoint.transform.rotation;
			location = true;
		}
		foreach (var renderer in renderers)
			renderer.enabled = true;
		foreach (var collider in colliders)
			collider.enabled = true;
		tank.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
	
		//canvas.SetActive (true);

		once = false;


		yield return new WaitForSeconds (3);

		location = false;

	}
}

