using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTurretCrank : MonoBehaviour {

	public float rot;
	float last;
	float tot = 0;

	void FixedUpdate(){
		float current = transform.eulerAngles.z;
		//float a = (transform.rotation.z * 100f);
		float cor;

		float checker;
		if (current != last) {
			Debug.Log (current + "is now " + "is last " + last);
			checker = current - last;
			if (checker < -200 && tot < 4) {
				tot++;
			} else if (checker < -200 && tot == 4) {
				tot = 1;
			}else if (checker > 200 && tot > 0) {
				tot--;
			} else if (checker > 200 && tot == 0) {
				tot = 3;
			}
		}

//		if (a >= 0 && a <= 90) {
//			tot = 1;
//		} else if (a > 90 && a <= 180) {
//			tot = 2;
//		} else if (a > 180 && a <= 270) {
//			tot = 3;
//		} else if ( a > 270){
//			tot = 4;
//		}

		cor = (current / 4) + (90 * tot);// + (90 * tot);// * tot);

		rot = cor;
		Debug.Log (cor + "is deg");
		last = current;
	}

}
