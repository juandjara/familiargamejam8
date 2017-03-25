using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public static EventManager instance { get; private set; }
	private int eventCounter = 0;

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
			eventCounter++;
		}
	}

	private void _triggerEvent(int index) {
		switch(index) {
			case 0:
				TextManager.instance.muestraMensaje("Se escucha un crujido en la cocina");
				return;
			default:
				return;
		}
	}
}
