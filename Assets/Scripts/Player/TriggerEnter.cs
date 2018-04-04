using UnityEngine;
using System;

public class TriggerEnter : MonoBehaviour {
	public Animator animator;
	public AudioSource audio;
	public bool timeLoop = false;

	public void setTrigger (string trigger) {
		animator.SetTrigger (trigger);

		if (audio != null && !timeLoop) {
			audio.Play ();
			audio = null;
		} else if (timeLoop)
			audio.Play ();
		animator.SetTrigger (null);
	}
}
