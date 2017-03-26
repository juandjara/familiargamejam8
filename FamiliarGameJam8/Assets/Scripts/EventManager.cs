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
			StartCoroutine (_triggerEvent(eventIndex));
			cambiaControles();
			eventCounter++;
		}
	}

	private void cambiaControles() {
		invierteGiro = !invierteGiro;
		invierteMove = !invierteMove;	
	}
 
	IEnumerator _triggerEvent(int index) {
		switch(index) {
			// como mostar dos textos
			// como en un rpg
			// se muestra el primer textos
			// y cuando el jugador pulse espacio
			// se pulsa el segundo
			case 0:
				// TODO: suena la vajilla fuerte
				TextManager.instance.muestraMensaje("Joder, ¿qué se habra roto? (ve hacia la cocina)");
				break;
			case 1:
				TextManager.instance.muestraMensaje("Todo esta en su sitio. Me serviré la ultima.");
				// TODO: se apagan las luces
				// y despues suena el bebe llorando
				// TODO: esperar x tiempo para el segundo mensaje
				yield return new WaitForSeconds(4f);
				TextManager.instance.muestraMensaje("(El cuadro de luces esta en el pasillo)");				
				break;
			case 2:
				// 
				TextManager.instance.muestraMensaje("Uff, se ha fundido, lo que me faltaba. Este dia no va a acabar nunca.");
				// TODO: Mostrar sombra en el cuarto del niño,
				//   que se vea desde el pasillo con un objeto dentro de la habitacion
				// TODO: reproducir sonido del corazon latiendo
				//   que se quede sonando durante el juego
				// TODO: esperar x tiempo para el segundo mensaje
				TextManager.instance.muestraMensaje("(Las velas estan en el salon)");				
				break;
			case 3:
				TextManager.instance.muestraMensaje("Hmm, Jack Daniels. Buena compañia para dormir");
				// mostrar imagen de niño fantasma en la entrada del pasillo durante medio segundo
				// reproducir sonido fuerte de grifo abiero
				// esperar x tiempo para el segundo mensaje
				TextManager.instance.muestraMensaje("¿Me he dejado la ducha abierta?");				
				break;
			case 4:
				// TODO: ponemos un video 
				// TODO: cambia a la camara del pasillo
				// TODO: pon al personaje en una posicion fija (x,y,z)
				TextManager.instance.muestraMensaje("¿Que coño ha sido eso?");
				// TODO: desactivar la cortina							
				// TODO: cerrar puerta dorm padre
				// TODO: cerrar puerta al salon
				break;				
			case 5:
				// llegamos al cuarto del niño y fin del juego
				// el padre ve el diario del niño y afronta su muerte
				// y recuerda como le molestaba que él bebiera
				// FIN DEL JUEGO
			default:
				break;
		}
	}
}
