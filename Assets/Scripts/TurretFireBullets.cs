using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFireBullets : MonoBehaviour {
	public GameObject bulletObj;
	public Transform bulletParent;


	void Start() 
	{
		StartCoroutine(FireBullet());
	}

	public IEnumerator FireBullet() 
	{        
		while (true)
		{
			//Create a new bullet
			GameObject newBullet = Instantiate(bulletObj, transform.position, transform.rotation) as GameObject;

			//Parent it to get a less messy workspace
			newBullet.transform.parent = bulletParent;

			//Add velocity to the bullet with a rigidbody
			newBullet.GetComponent<Rigidbody>().velocity = 20f * transform.forward;

			yield return new WaitForSeconds(2f);
		}
	}
}