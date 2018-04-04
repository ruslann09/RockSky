using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

	public bool sceneEnd;
	public float fadeSpeed = 1.5f;
	public string nextLevel;
	private Image _image;
	private bool sceneStarting;

	void Awake ()
	{
		_image = GetComponent<Image>();
		_image.enabled = true;
		sceneStarting = true;
		sceneEnd = false;
	}

	void Update ()
	{
		if(sceneStarting) StartScene();
		if(sceneEnd) EndScene();
	}

	public void StartScene ()
	{
		_image.color = Color.Lerp(_image.color, Color.clear, fadeSpeed * Time.deltaTime);

		if(_image.color.a <= 0.02f)
		{
			_image.color = Color.clear;
			_image.enabled = false;
			sceneStarting = false;
		}
	}

	public void EndScene ()
	{
		_image.enabled = true;
		_image.color = Color.Lerp(_image.color, Color.black, fadeSpeed * Time.deltaTime);

		if(_image.color.a >= 0.95f)
		{
			_image.color = Color.black;
			UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
		}
	}
}