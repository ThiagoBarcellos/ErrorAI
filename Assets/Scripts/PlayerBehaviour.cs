using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading;

public class PlayerBehaviour : NetworkBehaviour {

	[SyncVar]
	public string pname = "Player";

	[SyncVar]
	public bool team; //true para humano

	public GameObject SpawnPoint1;
	public GameObject SpawnPoint2;
	private bool layerone = true;
	private bool layertwo = false;
	private int changelayer = 0;
	public static bool turn = false;
	public static bool esquerda;
	private bool CanJump = false;
	public Rigidbody rb;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public int speed = -6;

	public bool pulando = false;
	public float walkSpeed;
	public bool atirando = false;
	public Animator anim;

	public bool vacuo = false;


	void Start () {
		if (team) {
			this.transform.position = SpawnPoint1.transform.position;
		}
		else{
			this.transform.position = SpawnPoint2.transform.position;
		}
		this.transform.Rotate (0f,-90f,0f);
		this.GetComponentInChildren<TextMesh> ().text = pname;
		rb = gameObject.GetComponent<Rigidbody> ();
		esquerda = true;
		anim.GetComponent<Animator> ();
	}

	
	void Update () {

		anim.SetBool ("atirando", atirando);
		anim.SetBool ("pulou", pulando);
		Cmdmovement ();
		atirando = false;
		if (Input.GetMouseButtonUp(0)) {
			CmdFire ();	

		}

	}
		
	#region movement
	void Cmdmovement()
	{
		var x = Input.GetAxis ("Horizontal");
		anim.SetFloat ("speed", Mathf.Abs (x));
		rb.velocity = new Vector3 (x * -walkSpeed, rb.velocity.y, 0);

		if (x > 0f && esquerda) {
			Flip ();
			speed = 6;
			turn = true;
		}

		else if (x < 0f && !esquerda) {
			Flip ();
			speed = -6;
			turn = false;
		}

		if (Input.GetKeyUp (KeyCode.W) && vacuo == false && layertwo == false && layerone == true && changelayer == 0 && this.transform.position.y > -3|| Input.GetKeyUp(KeyCode.UpArrow) && vacuo == false && layertwo == false && layerone == true && changelayer == 0 && this.transform.position.y > -3) {
			layertwo = true;
			layerone = false;
			changelayer = 1;
		}
		if (Input.GetKeyUp (KeyCode.S) && layerone == false && layertwo == true && changelayer == 2 && this.transform.position.y > -3|| Input.GetKeyUp(KeyCode.DownArrow) && layerone == false && layertwo == true && changelayer == 2 && this.transform.position.y > -3) {
			layerone = true;
			layertwo = false;
			changelayer = 1;
		} 

		if (Input.GetKeyUp (KeyCode.Space) && CanJump == true) {
			//rb.freezeRotation = true;
			rb.AddForce (Vector3.up * 4f, ForceMode.Impulse);
			pulando = true;
		}

		while (layertwo && layerone == false && changelayer == 1) {
			this.transform.Translate (0.8f, 0, 0);
			changelayer = 2;
		}
		while (layertwo == false && layerone && changelayer == 1) {
			this.transform.Translate (-0.8f, 0, 0);
			changelayer = 0;
		}

	}
		
	void Flip(){

		esquerda = !esquerda;
		//transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	void OnTriggerEnter(Collider coll)
	{
		/*CanJump = true;
		pulando = false;*/
		if (coll.gameObject.tag == "Vacuo") {
			vacuo = true;
			CanJump = true;
			pulando = false;
			Debug.Log ("Aí não pode");
		}

		else {
			vacuo = false;
			CanJump = true;
			pulando = false;
		}
		//Debug.Log ("Chão");
	}



	void OnTriggerExit(Collider coll)
	{
		CanJump = false;
		//Debug.Log ("Saiu");
	}

	void CmdFire()
	{
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;

		// Spawn the bullet on the Clients
		//NetworkServer.Spawn(bullet);

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
		atirando = true;

	}

	#endregion
	}