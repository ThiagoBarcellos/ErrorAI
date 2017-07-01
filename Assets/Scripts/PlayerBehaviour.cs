using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBehaviour : NetworkBehaviour {

	public GameObject SpawnPoint1;
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
	//public float andando = -1f;
	public bool atirando = false;
	public Animator anim;
	public bool pulou = false;

	void Start () {
		this.gameObject.transform.position = SpawnPoint1.transform.position;
		rb = gameObject.GetComponent<Rigidbody> ();
		esquerda = true;
		anim.GetComponent<Animator> ();
	}
	
	void Update () {
		/*if (!isLocalPlayer) {
			return;
		}*/

		//anim.SetFloat("Andando", andando);
		anim.SetBool("Pulando", pulou );
		//anim.SetBool ("Atirando", atirando);


		Cmdmovement ();
		atirando = false;
		if (Input.GetMouseButtonUp(0)) {
			CmdFire ();

		}

	}


	#region movement
	void Cmdmovement()
	{
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime;

		//andando = 1f;

		if (x > 0f && esquerda) {
			Flip ();
			speed = 6;
			//Debug.Log(speed);
			turn = true;
		}

		else if (x < 0f && !esquerda) {
			Flip ();
			speed = -6;
			//Debug.Log(speed);
			turn = false;
		}


			
		transform.Translate (0, 0, x);	


		if (Input.GetKeyUp (KeyCode.W) && layertwo == false && layerone == true && changelayer == 0 || Input.GetKeyUp(KeyCode.UpArrow) && layertwo == false && layerone == true && changelayer == 0) {
			layertwo = true;
			layerone = false;
			changelayer = 1;
		}
		if (Input.GetKeyUp (KeyCode.S) && layerone == false && layertwo == true && changelayer == 2 || Input.GetKeyUp(KeyCode.DownArrow) && layerone == false && layertwo == true && changelayer == 2) {
			layerone = true;
			layertwo = false;
			changelayer = 1;
		} 

		if (Input.GetKeyUp (KeyCode.Space) && CanJump == true) {
			Debug.Log ("pulou");
			rb.AddForce (Vector3.up * 4f, ForceMode.Impulse);
			pulou = true;
		}
		pulou = false;

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
		CanJump = true;
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
		//atirando = true;

	}

	#endregion
}