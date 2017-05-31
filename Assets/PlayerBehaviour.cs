using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBehaviour : NetworkBehaviour {

	private bool layerone = true;
	private bool layertwo = false;
	private int changelayer = 0;
	public static bool turn = false;
	public static int changeside = 0;
	public static float speed = 1f;
	private bool CanJump = false;
	public Rigidbody rb;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	void Update () {
		/*if (!isLocalPlayer) {
			return;
		}*/

		movement ();
	}

	#region movement
	void movement()
	{
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * speed;

		if (x > 0 && changeside == 0) {
			turn = true;
			changeside = 1;
			speed = 1f;
		}
		else if (x < 0 && changeside == 2) {
			turn = false;
			changeside = 1;
			speed = 1f;
		}
		else {
			turn = true;
			changeside = 0;
			speed = 0;
		}

		transform.Translate (x, 0, 0);	

		if (Input.GetKeyUp (KeyCode.W) && layertwo == false && layerone == true && changelayer == 0) {
			layertwo = true;
			layerone = false;
			changelayer = 1;
		}
		if (Input.GetKeyUp (KeyCode.S) && layerone == false && layertwo == true && changelayer == 2) {
			layerone = true;
			layertwo = false;
			changelayer = 1;
		} 

		if (Input.GetKeyUp (KeyCode.Space) && CanJump == true) {
			Debug.Log ("pulou");
			rb.AddForce (Vector3.up * 5f, ForceMode.Impulse);
		}

		while (layertwo && layerone == false && changelayer == 1) {
			this.transform.Translate (0, 0, 0.8f);
			changelayer = 2;
		}
		while (layertwo == false && layerone && changelayer == 1) {
			this.transform.Translate (0, 0, -0.8f);
			changelayer = 0;
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		CanJump = true;
		Debug.Log ("Chão");
	}
	void OnTriggerExit(Collider coll)
	{
		CanJump = false;		
		Debug.Log ("Saiu");
	}

	#endregion
}