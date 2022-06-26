using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour {
	public Transform[] s = new Transform[4];
	public int[] avail = new int[4];
	public GameObject ai;
	public int aimax;
	public int count;
	public int varc;
	public int delay = 0;
	public bool canspawn;


	void Start () {
		aimax = 3;
		count = 0;


		Checker ();

		Spawner ();
		StartCoroutine (Delayer ());
	}

	IEnumerator Delayer(){
		delay = 0;
		int rand = Random.Range (1, 4);
		if (avail [rand] == 111) {
			canspawn = false;
		} else {
			varc = rand;
			canspawn = true;
		}
		yield return new WaitForSeconds (2);
		delay = 1;
	}
	void Checker(){
		bool c0 = s [0].GetComponent<AISpawncheck> ().isin;
		bool c1 = s [1].GetComponent<AISpawncheck> ().isin;
		bool c2 = s [2].GetComponent<AISpawncheck> ().isin;
		bool c3 = s [3].GetComponent<AISpawncheck> ().isin;
		if (c0 == false) {
			avail [0] = 0;
		} else {
			avail [0] = 111;
		}
		if (c1 == false) {
			avail [1] = 1;
		} else {
			avail [1] = 111;
		}
		if (c2 == false) {
			avail [2] = 2;
		} else {
			avail [2] = 111;
		}
		if (c3 == false) {
			avail [3] = 3;
		} else {
			avail [3] = 111;
		}

	}

	void Spawner(){
		
		if (count < aimax  && delay == 1 && canspawn == true) {
			//int check = varc;
			GameObject aiclone;
			aiclone = Instantiate(ai, s[varc].position, s[varc].rotation) as GameObject;
			count++;
			StartCoroutine (Delayer ());
			Debug.Log ("Spawned!");
		}
	}


	void Update () {
		if (count < aimax) {
			Spawner ();
		}
	}

}
