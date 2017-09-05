using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoActive : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.enabled = false) {
            Reload();
        }
	}

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(5);
        this.enabled = true;
    }
}
