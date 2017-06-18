using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TrocaTela : MonoBehaviour {

	//Mudar de cena
	public void MudarCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }
}
