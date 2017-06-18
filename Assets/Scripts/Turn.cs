using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {

		if (PlayerBehaviour.turn == true) {
			Debug.Log ("esquerda");
				//PlayerBehaviour.esquerda = !PlayerBehaviour.esquerda;
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, 1);
			}
		if (PlayerBehaviour.turn == false) {
				Debug.Log ("direita");
				//PlayerBehaviour.esquerda = !PlayerBehaviour.esquerda;
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, -1);
			}
		}
	}

