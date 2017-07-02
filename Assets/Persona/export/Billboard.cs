using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Billboard : NetworkBehaviour {

	void Update () {
		transform.LookAt(Camera.main.transform);
	}
}