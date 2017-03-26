using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventToggler : MonoBehaviour {

	public int eventIndex = 0;

	private MeshRenderer renderer;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		renderer = this.transform.GetChild(0).GetComponent<MeshRenderer>();
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(EventManager.instance.eventCounter == eventIndex) {
			renderer.enabled = true;
		} else {
			renderer.enabled = false;
		}
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other) {
		EventManager.instance.triggerEvent(eventIndex);
	}

}
