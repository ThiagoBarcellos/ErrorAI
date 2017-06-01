using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {

		if (PlayerBehaviour.changestate) {
			if (PlayerBehaviour.turn) {
				transform.Rotate (0, 180f, 0);
				PlayerBehaviour.changestate = false;
			}
			if (!PlayerBehaviour.turn) {
				transform.Rotate (0, -180f, 0);
				PlayerBehaviour.changestate = false;
			}
		}
	}
}
