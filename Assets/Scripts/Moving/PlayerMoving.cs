using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMoving : MonoBehaviour {
	public GameObject interactiveObject, visibleStatement;
	public UnityEvent onBarFilled;
	public float timeToFill = 1.0f;
	private Image progressBarImage = null;
	public Coroutine barFillCoroutine = null;

	private bool fillingProcessIsRunning = false, gazeOver = false;

	public bool GazeOver {
		get {return gazeOver;}
		set {gazeOver = value;}
	}

	void Start ()
	{
		progressBarImage = GetComponent<Image>();

		if(progressBarImage == null)
		{
			Debug.LogError("Non a static argument for visibleStatement! Refresh prefabs!");
		}
	}

	public void StartFillingProgressBar()
	{
		if (gazeOver && !fillingProcessIsRunning) {
			barFillCoroutine = StartCoroutine ("Fill");
			fillingProcessIsRunning = !fillingProcessIsRunning;	
		}
	}

	public void StopFillingProgressBar()
	{
		if (!gazeOver && fillingProcessIsRunning) {
			StopCoroutine (barFillCoroutine);
			progressBarImage.fillAmount = 0.0f;
			fillingProcessIsRunning = !fillingProcessIsRunning;
		}
	}

	IEnumerator Fill() {
		float startTime = Time.time;
		float overTime = startTime + timeToFill;
		visibleStatement.transform.localScale = new Vector3 (visibleStatement.transform.localScale.x, 
			0.01f, 
										visibleStatement.transform.localScale.z);

		while(Time.time < overTime)
		{
			progressBarImage.fillAmount = Mathf.Lerp(0, 1, (Time.time - startTime) / timeToFill);

			visibleStatement.transform.localScale = new Vector3 (visibleStatement.transform.localScale.x, 
				visibleStatement.transform.localScale.y + 0.1f, 
				visibleStatement.transform.localScale.z);

			yield return null;
		}

		progressBarImage.fillAmount = 0.0f;

		if(onBarFilled != null)
		{
			onBarFilled.Invoke();
		}
	}

//	IEnumerator ExitFromFill () {
		
//	}
}