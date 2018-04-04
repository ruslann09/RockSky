using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustLoadLevel : MonoBehaviour {
	public void loadLevel (string level) {
		UnityEngine.SceneManagement.SceneManager.LoadScene (level);
	}
}
