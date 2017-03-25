using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textEvent : MonoBehaviour {

	bool mostrandoMensaje = false;
	float velocidadMensaje;
	float velocidadMensajeRapido = 0.03f;
	float velocidadMensajeLento = 0.06f;

	//public delegate string _SetText();
	//public static event _SetText SetText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			velocidadMensaje = velocidadMensajeRapido;
		} else {
			velocidadMensaje = velocidadMensajeLento;
		}
	}

	public void muestraMensaje(string mensaje) {
		StartCoroutine (muestraMensajeInterno (mensaje));
	}

	IEnumerator muestraMensajeInterno(string mensaje) {
		GetComponent<Text> ().text += "\n";
		for (int i = 0; i < mensaje.Length; i++) {
			GetComponent<Text> ().text += mensaje[i];
			//TODO ejecutar sonido de tecla
			yield return new WaitForSeconds (velocidadMensaje);
		}
		mostrandoMensaje = false;
	}
}
