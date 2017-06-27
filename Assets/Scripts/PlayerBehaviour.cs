﻿using System.Collections;
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

	void Start () {
		this.gameObject.transform.position = SpawnPoint1.transform.position;
		rb = gameObject.GetComponent<Rigidbody> ();
		esquerda = true;
	}
	
	void Update () {
		/*if (!isLocalPlayer) {
			return;
		}*/

			Cmdmovement ();
		if (Input.GetMouseButtonUp(0)) {
			CmdFire ();
		}
	}


	#region movement
	void Cmdmovement()
	{
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime;

		if (x > 0f && esquerda) {
			Flip ();
			speed = 6;
			//Debug.Log(speed);
			turn = false;
		}

		else if (x < 0f && !esquerda) {
			Flip ();
			speed = -6;
			//Debug.Log(speed);
			turn = true;


		}
			
		transform.Translate (x, 0, 0);	

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
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * speed;

		// Spawn the bullet on the Clients
		//NetworkServer.Spawn(bullet);

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}

	#endregion
}