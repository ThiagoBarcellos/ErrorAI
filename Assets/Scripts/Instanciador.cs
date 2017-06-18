using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour {

	public Transform PosforinstanHum;
	public Transform PosforinstanRob;
	public float RotacaoEmX, RotacaoEmY, RotacaoEmZ;
	public GameObject[] Players;

	void Start () {
		//onde instanciar e o que instanciar
		if(EscolhaPersona.SelecaoAtual == 3 && EscolhaPersona.SelecaoAtual == 4 ) {
			Instantiate (Players [Data.PersonaAInstanciar], PosforinstanHum);
		}

		if(EscolhaPersona.SelecaoAtual == 1 && EscolhaPersona.SelecaoAtual == 2 ) {
			Instantiate (Players [Data.PersonaAInstanciar], PosforinstanRob);
		}
	}

}
