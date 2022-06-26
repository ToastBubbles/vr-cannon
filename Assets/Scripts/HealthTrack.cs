using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTrack : MonoBehaviour {
	public Transform tankPos;
	public Transform respawnPoint;
	public GameObject self;
	public GameObject shield;
	public GameObject bullet;
	public GameObject tank;
	public GameObject camera;
	public GameObject explosion;
	public GameObject charred;
	public GameObject[] respawns;
	public bool test;
	public float dmg;
	public float current;
	public float cursh;
	public float hp;
	public float sp;
	public float fullhp;
	public float fullsp;
	public bool once;
	public bool location;

	public bool cam;

	void Start(){
		fullsp = 100f;
		fullhp = 100f;
		hp = fullhp;
		sp = fullsp;
		//dmg = 25f;
		cam = false;
		once = false;
		location = false;
			
	}

	void FixedUpdate()
	{
		current = hp;
		cursh = sp;
		self.GetComponent<Image> ().fillAmount = current/100;
		shield.GetComponent<Image> ().fillAmount = cursh/100;

		Debug.Log("Health : " + hp + " Damage taken: " + dmg + " current: " + current + " current shield: " + cursh);

		if (self.GetComponent<Image> ().fillAmount <= 0f) {
			StartCoroutine (Respawn ());
			Debug.Log ("died");
		}
	}
	public void DMG (){
		Debug.Log ("RUNNNING");
		if (sp >= 25) {
			cursh = (sp -= dmg);
			camera.transform.parent = null;
		} else {
			current = (hp -= dmg);
		}
		Debug.Log (current);
		return;
	}
	IEnumerator Respawn (){
		cam = true;

			var renderers = tank.GetComponentsInChildren<Renderer> ();
			foreach (var renderer in renderers)
				renderer.enabled = false;
			var colliders = tank.GetComponentsInChildren<Collider> ();
			foreach (var collider in colliders)
				collider.enabled = false;
			tank.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			//tank.GetComponent<EasyDrive> ().rotSpeed = 0;
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
			location = true;
		}
		foreach (var renderer in renderers)
			renderer.enabled = true;
		foreach (var collider in colliders)
			collider.enabled = true;
		tank.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		//tank.GetComponent<EasyDrive> ().rotSpeed = 40;
		once = false;
		cam = false;

		yield return new WaitForSeconds (3);

		location = false;
	}
}
