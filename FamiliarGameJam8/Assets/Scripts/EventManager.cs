using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public static EventManager instance { get; private set; }
	public int eventCounter = 0;

	public bool invierteMove = false;
	public bool invierteGiro = false;

	void Awake() {
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}

	public void triggerEvent(int eventIndex) {
		if(eventIndex == eventCounter) {
			// trigger event and increment counter
			_triggerEvent(eventIndex);
			cambiaControles();
			eventCounter++;
		}
	}

	private void cambiaControles() {
		invierteGiro = !invierteGiro;
		invierteMove = !invierteMove;	
	}
 
	private void _triggerEvent(int index) {
		switch(index) {
			case 0:
				// TODO: suena la vajilla fuerte
				TextManager.instance.muestraMensaje("Joder, ¿qué se habra roto? (ve hacia la cocina)");
				return;
			case 1:
				TextManager.instance.muestraMensaje("Todo esta en su sitio. Me serviré la ultima.");
				// TODO: se apagan las luces
				// y despues suena el bebe llorando
				// TODO: esperar x tiempo para el segundo mensaje
				TextManager.instance.muestraMensaje("(El cuadro de luces esta en el pasillo)");				
				return;
			case 2:
				// 
				TextManager.instance.muestraMensaje("Uff, lo que me faltaba. Este dia no va a acabar nunca.");
				// TODO: Mostrar sombra en el cuarto del niño,
				//   que se vea desde el pasillo con un objeto dentro de la habitacion
				// TODO: reproducir sonido del corazon latiendo
				//   que se quede sonando durante el juego
				// TODO: esperar x tiempo para el segundo mensaje
				return;
			
			default:
				return;
		}
	}
}
