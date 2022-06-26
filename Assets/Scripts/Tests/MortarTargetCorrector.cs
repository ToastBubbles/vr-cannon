using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Source.Trajectory;

public class MortarTargetCorrector : MonoBehaviour {
	public GameObject target;
	public Vector3 end;
	public GameObject linescript;
	private int sel;


	void Start () {
		sel = PlayerPrefs.GetInt("turret");
	}

	void Update () {
		if (sel == 2) {
			LineRenderer lr = target.GetComponent<LineRenderer> ();
			linescript = GameObject.FindGameObjectWithTag ("laser");
			end = linescript.GetComponent<ProjectileTrajectory> ().endpoint;
			Debug.Log (end);
			//transform.Translate(Vector3.right * 6 * Time.deltaTime);
			//transform.Translate(Vector3.up * -2 * Time.deltaTime);

			RaycastHit hit = new RaycastHit ();
			if (Physics.Raycast (end, -Vector3.up, out hit)) {
				target.transform.position = Vector3.MoveTowards (target.transform.position, hit.point, 10);
				//target.transform.position = Vector3.MoveTowards (target.transform.position, end, 5);
			}
			lr.SetPosition (0, end);
			lr.SetPosition (1, hit.point);
			lr.SetWidth (0.4f, 0.2f);
			if (Input.GetMouseButtonDown (0)) {
				StartCoroutine (Delay ());
			}
		}

	}
	IEnumerator Delay(){
		GameObject spot;
		spot = Instantiate (target, target.transform.position, Quaternion.identity);
		yield return new WaitForSeconds (8);
		Destroy(spot);
	}

}
