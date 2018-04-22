using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCanvas : MonoBehaviour {
	public GameObject canvas;

	public void hideCanvas () {
		canvas.SetActive (false);
	}

	public void showCanvas () {
		canvas.SetActive (true);
	}
}
