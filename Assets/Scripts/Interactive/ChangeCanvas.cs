using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvas : MonoBehaviour {
	public GameObject isOpening, willBeOpening;

	public void ChangeMonitor () {
		isOpening.SetActive (false);
		willBeOpening.SetActive (true);
	}
}
