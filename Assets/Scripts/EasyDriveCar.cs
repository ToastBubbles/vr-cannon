using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyDriveCar : MonoBehaviour {
	//public float speed;
	public float rotSpeed;
	Rigidbody rbTank;
	public static float fowardBack;
	public static float leftRight;
	public int statSpeed;
	public float health;
	private float scroll = 1f;
	private float scrollSlow = 0.4f;
	public GameObject leftTread;
	public GameObject rightTread;
	public GameObject leftrTread;
	public GameObject rightrTread;


	public GameObject hP;


	//bool foward = false;
	//bool back = false;


	void Start () {
		health = 100f;
	}

	void Awake(){
		rbTank = GetComponent <Rigidbody> ();
	}

	public void Foward(){
		//foward = true;
	}
	public void Back(){
		//back = true;
	}
	

	void Update () {
		
		float foward = Time.time * -scroll;
		float back = Time.time * scroll;
		float fowardSlow = Time.time * -scrollSlow;
		float backSlow = Time.time * scrollSlow;

		//foward and backwards
		if (Input.GetAxis ("Vertical") > 0 && Input.GetAxis ("Horizontal") == 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 ( foward,0);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (foward,0);
			leftrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 ( foward,0);
			rightrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (foward,0);
		} else if (Input.GetAxis ("Vertical") < 0 && Input.GetAxis ("Horizontal") == 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (back,0);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (back,0);
			leftrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (back,0);
			rightrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (back,0);
		}
		//Left and right
		else if (Input.GetAxis ("Vertical") == 0 && Input.GetAxis ("Horizontal") > 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (foward,0);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (back,0);
			leftrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (foward,0);
			rightrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (back,0);
		} else if (Input.GetAxis ("Vertical") == 0 && Input.GetAxis ("Horizontal") < 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (back,0);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (foward,0);
			leftrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (back,0);
			rightrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (foward,0);
		}
		//foward banking
		else if (Input.GetAxis ("Vertical") > 0 && Input.GetAxis ("Horizontal") > 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (foward,0);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (fowardSlow,0);
			leftrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (foward,0);
			rightrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (fowardSlow,0);
		} else if (Input.GetAxis ("Vertical") > 0 && Input.GetAxis ("Horizontal") < 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (fowardSlow,0);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (foward,0);
			leftrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (fowardSlow,0);
			rightrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (foward,0);
		}
		//backwards banking
		else if (Input.GetAxis ("Vertical") < 0 && Input.GetAxis ("Horizontal") > 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (backSlow,0);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (back,0);
			leftrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (backSlow,0);
			rightrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (back,0);
		} else if (Input.GetAxis ("Vertical") < 0 && Input.GetAxis ("Horizontal") < 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (back,0);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (backSlow,0);
			leftrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (back,0);
			rightrTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (backSlow,0);
		}


		statSpeed = GetComponent<Stats> ().curspeed;
		fowardBack = Input.GetAxis ("Vertical") * statSpeed * Time.deltaTime * 1.5f;
		leftRight = Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime * 1.5f;
		//leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, offsetL);


		if(Input.GetKeyDown("f")){
			hP.GetComponent<Image>().fillAmount = .3f;
		}

		//if (foward == true) {
			//fowardBack = -1f;
		//}
		//if (back == true) {
			//fowardBack = 1f;
		//}
	}
	void FixedUpdate(){
		TankFowardBack ();
		TankRotateLeftRight ();
	}
	void TankFowardBack()
	{
		Vector3 moveFB = transform.forward * fowardBack * statSpeed * Time.deltaTime;
		rbTank.MovePosition (rbTank.position + moveFB);
	}
	void TankRotateLeftRight()
	{
		Quaternion rotateLR = Quaternion.Euler (0f, leftRight, 0f);
		rbTank.MoveRotation (rbTank.rotation * rotateLR);
	}
	//public void SwitchBoolsOff(){
	//	foward = false;
	//	back = false;
	//}
}
