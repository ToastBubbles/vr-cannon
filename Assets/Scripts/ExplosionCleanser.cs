using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCleanser : MonoBehaviour {
	public GameObject self;
	void Start()
	{
		StartCoroutine(Destroy());
	}

	IEnumerator Destroy()
	{
		
		yield return new WaitForSeconds(4);
		Destroy (self);
	}
}
