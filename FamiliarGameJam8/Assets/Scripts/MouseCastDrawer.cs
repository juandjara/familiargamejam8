using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCastDrawer : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)) {
			Camera cam = Camera.main;
			var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
			Debug.DrawLine(transform.position, mousePos, Color.black);
		}
	}
}
