using System.Collections;
using UnityEngine;

public class Data : MonoBehaviour {

	public GameObject[] Datas;
	public static int PersonaAInstanciar;

	void Awake(){
		/*Datas = GameObject.FindGameObjectsWithTag ("data");
		if (Datas.Length >= 2)
			Destroy (Datas [0]);*/

		DontDestroyOnLoad (transform.gameObject);
	}



}
