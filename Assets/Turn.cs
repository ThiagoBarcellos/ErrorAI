using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
		if (PlayerBehaviour.turn && PlayerBehaviour.changeside == 1) {
			transform.Rotate (0, 180f, 0);
			PlayerBehaviour.changeside = 2;
		}
		if (!PlayerBehaviour.turn && PlayerBehaviour.changeside == 1) {
			transform.Rotate (0, -180f, 0);
			PlayerBehaviour.changeside = 0;
		}
	}
}
