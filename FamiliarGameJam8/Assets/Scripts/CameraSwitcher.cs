using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {

	public Camera[] cameras;
	public static CameraSwitcher instance { get; private set; }

	void Awake() {
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}

    public void enableCamera(int targetIndex) {
		if(targetIndex < 0 || targetIndex >= cameras.Length) {
			Debug.LogError("Invalid index. This camera does not exist");
			return;
		}
		TextManager.instance.muestraMensaje("mostrando camara "+targetIndex);
		for(int index = 0; index < cameras.Length; index++) {
			Camera cam = cameras[index];
			if(index == targetIndex) {
				cam.enabled = true;
			} else {
				cam.enabled = false;
			}
		}
	}
}
