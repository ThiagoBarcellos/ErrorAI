using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

	public GameObject SpawnPoint1;
	public GameObject SpawnPoint2;

	private bool able = false;

	public static int Human1;
	public GameObject Humano1;
	public static int Human2;
	public GameObject Humano2;
	public static int Robot1;
	public GameObject Robo1;
	public static int Robot2;
	public GameObject Robo2;

	[Server]
	void Start () {
		Humano1.transform.localPosition = SpawnPoint1.transform.localPosition;
		Human1 = 1;
		Human2 = 1;
		Robot1 = 1;
		Robot2 = 1;
	}

	[Client]
	void Update () {
		if (Human1 == 0)
		{
			Respawn ();
			if (able) {
				Debug.Log ("Morreu");
				Humano1.transform.position = SpawnPoint1.transform.position;
				Human1 = 1;
				able = false;
			}
		}
		if (Human2 == 0) {
			Respawn ();
			if (able) {
				Instantiate (Humano2, SpawnPoint1.transform.localPosition, Quaternion.identity);
			}
		}
		if (Robot1 == 0) {
			Respawn ();
			if (able) {
				Instantiate (Robo1, SpawnPoint2.transform.localPosition, Quaternion.identity);
			}
		}
		if (Robot2 == 0) {
			Respawn ();
			if (able) {
				Instantiate (Robo2, SpawnPoint2.transform.localPosition, Quaternion.identity);
			}
		}
	}

	[Server]
	IEnumerator Respawn(){
		yield return new WaitForSeconds (2);
		able = true;
	}
}
