using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 50f;
	public float rotateSpeed = 100f;
	private Transform playerTransform;

	// Use this for initialization
	void Start () {
		playerTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		float turnValue = Input.GetAxis("Horizontal");
		float xAxis = Input.GetAxis("Vertical");

		turn(turnValue);
		
		Ray ray = new Ray(transform.position+transform.right*0.8f, transform.right*xAxis);
		Debug.DrawRay (ray.origin, ray.direction , Color.black);

		RaycastHit hit;

		//dispara rayo y lo guarda en la variable de out	
		if (Physics.Raycast (ray.origin, ray.direction * xAxis, out hit)) {
			if (hit.distance < 0.1f) {
				Debug.Log (" obj " + hit.collider.gameObject.name);
			}
		}

		movement(xAxis);
	}

	void movement(float xAxis) {
		Vector3 movement = new Vector3(xAxis, 0, 0) * moveSpeed * Time.deltaTime;
		playerTransform.Translate(movement);		
	}

	void turn(float turnValue) {
		Vector3 rotationVector = new Vector3(0, turnValue, 0) * rotateSpeed * Time.deltaTime;
		playerTransform.Rotate(rotationVector);
	}
}
