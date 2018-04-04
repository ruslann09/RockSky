using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvas : MonoBehaviour {
	public void ChangeMonitor (GameObject willBeOpening) {
		transform.gameObject.SetActive (false);
		willBeOpening.SetActive (true);
	}
}
