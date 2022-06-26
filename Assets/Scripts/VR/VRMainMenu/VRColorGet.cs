using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRColorGet : MonoBehaviour {
	public GameObject tank1;
	public GameObject tank2;

	public GameObject single;
	public GameObject dual;
	public GameObject mortar;

	public GameObject rl;
	public GameObject gl;
	public GameObject bl;

	public GameObject selector;
	public string current = null;

	private float r;
	private float g;
	private float b;

	void Start () {
		
	}
	void Update(){
		current = selector.GetComponent<ItemColorDet> ().curItem;
		r = rl.GetComponent<VRRedLever> ().fixer;
		g = gl.GetComponent<VRRedLever> ().fixer;
		b = bl.GetComponent<VRRedLever> ().fixer;

		Color32 updated = new Color (r, g, b, 1f);

		if (current == "Standard") {
			tank1.GetComponent<Renderer> ().material.color = updated;
		} else if (current == "Wheels") {
			tank2.GetComponent<Renderer> ().material.color = updated;
		}else if (current == "Single") {
			single.GetComponent<Renderer> ().material.color = updated;
		}else if (current == "Dual") {
			dual.GetComponent<Renderer> ().material.color = updated;
		}else if (current == "Mortar") {
			mortar.GetComponent<Renderer> ().material.color = updated;
		}

	}

}
