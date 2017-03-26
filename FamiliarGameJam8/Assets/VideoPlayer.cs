using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoPlayer : MonoBehaviour {

	public MovieTexture movie;
	private AudioSource audio;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start() {
		PlayVideo(movie);
	}
	
	
	public void PlayVideo(MovieTexture movie)
	{
		GetComponent<RawImage>().enabled = true;
		GetComponent<RawImage>().texture = movie as MovieTexture;
		audio = GetComponent<AudioSource>();
		audio.clip = movie.audioClip;

		movie.Play();
		audio.Play();
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space)) {
			GetComponent<RawImage>().enabled = false;
			if(EventManager.instance.eventCounter == 6) {
				Application.Quit();
			}
		}
	}
}
