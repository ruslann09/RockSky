using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMoving : MonoBehaviour {
	public Transform objectiveCenter;
	public float speed = 0.1f, maxHeigh = 500, timeToWait = 0.5f;
	private float curTime;
	public bool isStart;

	private void Update () {
		curTime += Time.deltaTime;

		if (curTime >= timeToWait) {
			timeToWait = 0f;
			if (isStart && curTime >= speed && objectiveCenter != null && objectiveCenter.localScale.y < maxHeigh) {
				curTime = 0f;

				objectiveCenter.gameObject.SetActive (true);

				objectiveCenter.localScale = new Vector3 (objectiveCenter.localScale.x, objectiveCenter.localScale.y + speed*500, 
					objectiveCenter.localScale.z);
			} else if (!isStart && curTime >= speed && objectiveCenter != null && objectiveCenter.localScale.y > 0) {
				objectiveCenter.localScale = new Vector3 (objectiveCenter.localScale.x, 0f, 
					objectiveCenter.localScale.z);
				objectiveCenter.gameObject.SetActive (false);

				//curTime = 0f;

				//objectiveCenter.localScale = new Vector3 (objectiveCenter.localScale.x, objectiveCenter.localScale.y - speed*200, 
					//objectiveCenter.localScale.z);
			}
		}
	}
}