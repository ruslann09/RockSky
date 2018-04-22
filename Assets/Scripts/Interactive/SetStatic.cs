using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStatic : MonoBehaviour {
	private bool isPaused;
	public float timeToPause = 0.7f;

	public void onPause () {
		StartCoroutine (setPause ());
	}

	private IEnumerator setPause () {
		yield return new WaitForSeconds (timeToPause);

		if (!isPaused) {
			Time.timeScale = 0; 
			isPaused = true; 
		} else {
			Time.timeScale = 1;
			isPaused = false;
		}
	}
}
