using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	bool mostrandoMensaje = false;
	float velocidadMensaje;
	float velocidadMensajeRapido = 0.03f;
	float velocidadMensajeLento = 0.06f;

	public Text targetText;
	public static TextManager instance;

	//public delegate string _SetText();
	//public static event _SetText SetText;

	void Awake() {
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			velocidadMensaje = velocidadMensajeRapido;
		} else {
			velocidadMensaje = velocidadMensajeLento;
		}
	}

	public void ChangeText(string text) {
		targetText.text = text;
	}

	public void muestraMensaje(string mensaje) {
		StartCoroutine (muestraMensajeInterno (mensaje));
	}

	IEnumerator muestraMensajeInterno(string mensaje) {
		targetText.text = "";
		for (int i = 0; i < mensaje.Length; i++) {
			targetText.text += mensaje[i];
			//TODO ejecutar sonido de tecla
			yield return new WaitForSeconds (velocidadMensaje);
		}
		mostrandoMensaje = false;
	}
}
