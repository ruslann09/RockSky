using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {
	public void loadLevel (string scene) {
		UnityEngine.SceneManagement.SceneManager.LoadScene (scene);
	}
}