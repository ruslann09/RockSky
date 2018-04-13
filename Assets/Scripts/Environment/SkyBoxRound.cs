using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRound : MonoBehaviour {
	public Transform skyBox;
	public float timeToRotate = 0.1f, angle = 0.1f;
	private float timeIsNow;

	void Update () {
		timeIsNow += Time.deltaTime;

		if (skyBox != null && timeIsNow >= timeToRotate) {
			timeIsNow = 0f;

			skyBox.Rotate(0, angle, 0);
		}
	}
}
