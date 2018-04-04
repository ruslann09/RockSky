using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageProgressBar : MonoBehaviour
{
	public GameObject interactiveObject;
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
			Debug.LogError("There is no referenced image on this component!");
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

	IEnumerator Fill()
	{
		float startTime = Time.time;
		float overTime = startTime + timeToFill;

		while(Time.time < overTime)
		{
			progressBarImage.fillAmount = Mathf.Lerp(0, 1, (Time.time - startTime) / timeToFill);
			yield return null;
		}

		progressBarImage.fillAmount = 0.0f;

		if(onBarFilled != null)
		{
			onBarFilled.Invoke();
		}
	}
}