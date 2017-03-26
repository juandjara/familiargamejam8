using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public static EventManager instance { get; private set; }
	public int eventCounter = 0;

	public bool invierteMove = false;
	public bool invierteGiro = false;

	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";

	public Transform player;

	public AudioSource audioPlatos;
	public AudioSource audioLlantoBebe;
	public AudioSource audioAgua;
	public AudioSource audioBebe2;
	public AudioSource audioRisaBebe;

	public Transform luces;

	public Texture intro;

	public GameObject videoPlayer;

	public MovieTexture movie_ducha;
	public MovieTexture movie_fin;

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
		string msg = "";
		float velMensaje = TextManager.instance.velocidadMensaje;
		switch(index) {
			case 0:
				audioPlatos.Play();
				TextManager.instance.muestraMensaje("Eso venía de la cocina. Joder, ¿qué se habra roto?");
				break;
			case 1:
				msg = "Todo esta en su sitio. Me serviré la ultima.";
				TextManager.instance.muestraMensaje(msg);
				horizontalAxis = "Vertical";
				verticalAxis = "Horizontal";
				yield return new WaitForSeconds(1f + (msg.Length * velMensaje));
				// TODO: se apagan las luces

				GameObject[] luces = GameObject.FindGameObjectsWithTag("Luz");
				foreach(GameObject luz in luces) {
					luz.GetComponent<Light>().enabled = false;
				}

				audioLlantoBebe.Play();
				audioRisaBebe.Play();

				TextManager.instance.muestraMensaje("Tendré que comprobar el cuadro de luces en el pasillo");				
				break;
			case 2:
				msg = "Uff, se ha fundido, lo que me faltaba. Este dia no va a acabar nunca.";
				TextManager.instance.muestraMensaje(msg);
				
				// TODO: reproducir sonido del corazon latiendo
				//   que se quede sonando durante el juego
				
				yield return new WaitForSeconds(1f + (msg.Length * velMensaje));
				TextManager.instance.muestraMensaje("Tendré que ir al salón a por velas.");				
				break;
			case 3:
				msg = "Hmm, Jack Daniels. Buena compañia para dormir";
				TextManager.instance.muestraMensaje(msg);
				horizontalAxis = "Horizontal2";
				verticalAxis = "Vertical2";
				// mostrar imagen de niño fantasma en la entrada del pasillo durante medio segundo
				
				audioAgua.Play();

				yield return new WaitForSeconds(1f + (msg.Length * velMensaje));
				TextManager.instance.muestraMensaje("¿Me he dejado la ducha abierta?");				
				break;
			case 4:
				// TODO: ponemos un video 
				
				horizontalAxis = "Horizontal2";
				verticalAxis = "Vertical2";

				videoPlayer.GetComponent<VideoPlayer>().PlayVideo(movie_ducha);

				Vector3 position = new Vector3(-1f, 0f, -0.8f);
				player.position = position;
				CameraSwitcher.instance.enableCamera(1);
				TextManager.instance.muestraMensaje("¿Que coño ha sido eso?");
				// TODO: desactivar la cortina							
				// TODO: cerrar puerta dorm padre
				// TODO: cerrar puerta al salon
				break;				
			case 5:

				audioBebe2.Play();

				// llegamos al cuarto del niño y fin del juego
				// el padre ve el diario del niño y afronta su muerte
				// y recuerda como le molestaba que él bebiera
				// FIN DEL JUEGO
				TextManager.instance.muestraMensaje("Este cuento se acabo");

				videoPlayer.GetComponent<VideoPlayer>().PlayVideo(movie_fin);

				break;
			default:
				break;
		}
	}
}
