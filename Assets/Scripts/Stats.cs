using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	public int health;
	public int armor;
	public int attack;
	public int speed;
	public int rotSpeed;

	public int healthLvl;
	public int armorLvl;
	public int attackLvl;
	public int speedLvl;
	public int rotSpeedLvl;

	public int healthLvlMax;
	public int armorLvlMax;
	public int attackLvlMax;
	public int speedLvlMax;

	public int[] healthT;
	public int[] armorT;
	public int[] attackT;
	public int[] speedT;
	public int[] rotSpeedT;

	public int curhealth;
	public int curarmor;
	public int curattack;
	public int curspeed;
	public int currotSpeed;

	void Start () {
		curhealth = healthT [1];
		curarmor = armorT [1];
		curattack = attackT [1];
		curspeed = speedT [1];
		currotSpeed = rotSpeedT [1];
	}
	

	void Update () {
		//Debug.Log (curspeed);
	}
}
