using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMCamera : MonoBehaviour {
    public Transform cam;


	// Use this for initialization
	void Start () {
		
	}
	
    void Update()
    {
        transform.rotation = cam.rotation;
        transform.Translate(Vector3.forward * (10 * Time.deltaTime));
    }
	// Update is called once per frame

}
