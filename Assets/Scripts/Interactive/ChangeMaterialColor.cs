using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour {
	public Material mat;
	private bool isOff = false;

	public void Changing () {
		if (!isOff) {
			isOff = true;
			mat.SetColor ("_EmissionColor", new Color32 (0, 0, 0, 255));
		} else {
			isOff = false;
			mat.SetColor ("_EmissionColor", new Color32 (255, 255, 255, 255));
		}
	}
}
