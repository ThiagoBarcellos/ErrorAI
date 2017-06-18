using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EscolhaPersona : MonoBehaviour {

	public Texture[] Personagem;
	public Texture PersonagemEscolhido;
	public static int SelecaoAtual;

	void Start(){
		SelecaoAtual = 0;
}
	public void FemSelec () {
		SelecaoAtual = 1;//posição correspondente no array personagem
	}

	public void MasSelec () {
		SelecaoAtual = 2;		
	}

	public void FemHumSelec () {
		SelecaoAtual = 3;		
	}

	public void MasHumSelec () {
		SelecaoAtual = 4;		
	}

	void Update(){
		if (SelecaoAtual > 0) {
			PersonagemEscolhido = Personagem [SelecaoAtual];
		}

		else {
			Debug.Log ("Escolha um personagem");
		}
	}
		
	public void MudarCena(string cena)
	{
		Data.PersonaAInstanciar = SelecaoAtual;
		SceneManager.LoadScene(cena);
	}

}
		
