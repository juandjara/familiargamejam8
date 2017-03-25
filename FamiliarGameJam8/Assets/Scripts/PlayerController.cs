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
		movement(xAxis);
		turn(turnValue);
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
