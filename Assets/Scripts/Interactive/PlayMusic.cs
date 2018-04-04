using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour {
	private bool isPlaying;
	public AudioSource audio;

	public void playMusic () {
		if (!isPlaying && audio != null) {
			audio.Play ();
			isPlaying = true;
		} else {
			audio.Stop ();
			isPlaying = false;
		}
	}
}
