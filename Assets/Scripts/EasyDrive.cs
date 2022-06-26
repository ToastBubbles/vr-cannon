using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyDrive : MonoBehaviour {
	public float speed;
	//public float rotSpeed;
	Rigidbody rbTank;
	public static float fowardBack;
	public static float leftRight;
	public int statSpeed;
	public int statRot;
	public float health;
	private float scroll = 0.5f;
	private float scrollSlow = 0.2f;
	public GameObject leftTread;
	public GameObject rightTread;
	public GameObject grounder;
	bool gg;
	private int goodspeed;

	public int malfunction = 0;
	public int malfunctionR = 0;

	public float rawshaft;
	public float fbshaft;
	public GameObject driveShaft;

	public GameObject hP;

	private float left;
	private float right;
	public GameObject leftobj;
	public GameObject rightobj;
	private float fowardForce;
	private float turnForce;


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
		left = leftobj.GetComponent<TankVRLeftLever> ().leftForce;
		right = rightobj.GetComponent<TankControllVR> ().rightForce;
		DriveCalc ();
		rawshaft = driveShaft.transform.localEulerAngles.x;
		fbshaft = rawshaft / 45;
		Debug.Log ("fbshaft");
		gg = grounder.GetComponent<TankGroundcheck> ().isin;
		float foward = Time.time * -scroll;
		float back = Time.time * scroll;
		float fowardSlow = Time.time * -scrollSlow;
		float backSlow = Time.time * scrollSlow;

		//foward and backwards
		if (Input.GetAxis ("Vertical") > 0 && Input.GetAxis ("Horizontal") == 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, foward);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, foward);
		} else if (Input.GetAxis ("Vertical") < 0 && Input.GetAxis ("Horizontal") == 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, back);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, back);
		}
		//Left and right
		else if (Input.GetAxis ("Vertical") == 0 && Input.GetAxis ("Horizontal") > 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, foward);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, back);
		} else if (Input.GetAxis ("Vertical") == 0 && Input.GetAxis ("Horizontal") < 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, back);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, foward);
		}
		//foward banking
		else if (Input.GetAxis ("Vertical") > 0 && Input.GetAxis ("Horizontal") > 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, foward);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, fowardSlow);
		} else if (Input.GetAxis ("Vertical") > 0 && Input.GetAxis ("Horizontal") < 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, fowardSlow);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, foward);
		}
		//backwards banking
		else if (Input.GetAxis ("Vertical") < 0 && Input.GetAxis ("Horizontal") > 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, backSlow);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, back);
		} else if (Input.GetAxis ("Vertical") < 0 && Input.GetAxis ("Horizontal") < 0) {
			leftTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, back);
			rightTread.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, backSlow);
		}


		statSpeed = GetComponent<Stats> ().curspeed;
		statRot = GetComponent<Stats> ().currotSpeed;


		//fowardBack = Input.GetAxis ("Vertical") * statSpeed * Time.deltaTime;
		//leftRight = Input.GetAxis ("Horizontal") * statRot * Time.deltaTime;

		fowardBack = Input.GetAxis ("Vertical") * statSpeed * Time.deltaTime;
		leftRight = Input.GetAxis ("Horizontal") * statRot * Time.deltaTime;
		//transform.position = Mathf.Lerp (fowardBack, goodspeed, Time.deltaTime);

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
	void DriveCalc(){
		turnForce = (left - right);
		if (left > 0 && right > 0) {
			fowardForce = Mathf.Abs ((left + right)/2);
		}
		if (left < 0 && right < 0) {
			fowardForce = Mathf.Abs ((left + right)/-2);
		}


	}
	void FixedUpdate(){
		TankFowardBack ();
		TankRotateLeftRight ();
	}
	void TankFowardBack()
	{
		//original mechanic

			//Vector3 moveFB = transform.forward * fowardBack * statSpeed * Time.deltaTime;
		Vector3 moveFB = transform.forward * (fowardBack + malfunction + fowardForce) * statSpeed * Time.deltaTime;
			
			rbTank.MovePosition (rbTank.position + moveFB);
		if (gg == true) {

		}


	}
	void TankRotateLeftRight()
	{
		Quaternion rotateLR = Quaternion.Euler (0f, (leftRight + malfunctionR + turnForce), 0f);
		rbTank.MoveRotation (rbTank.rotation * rotateLR);
	}
	//public void SwitchBoolsOff(){
	//	foward = false;
	//	back = false;
	//}
}
