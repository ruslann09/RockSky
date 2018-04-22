using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRandomScene : MonoBehaviour {
	public void startRandomMap () {
		UnityEngine.SceneManagement.SceneManager.LoadScene (Random.Range (1, UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings));
	}
}
