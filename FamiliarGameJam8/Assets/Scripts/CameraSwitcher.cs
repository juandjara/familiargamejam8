using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {

	public Camera leftCamera;
    public Camera rightCamera;

    public void ShowOverheadView() {
        leftCamera.enabled = false;
        rightCamera.enabled = true;
    }
    
    public void ShowFirstPersonView() {
        leftCamera.enabled = true;
        rightCamera.enabled = false;
    }
}
