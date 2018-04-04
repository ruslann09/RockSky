using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUp : MonoBehaviour {
	public GameObject gameObject;
	public float sizeKoeff = 1.5f;
	public float heightKoeff = 1.5f;

	public void sizeUp () {
		gameObject.transform.localScale *= sizeKoeff;
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x,
			gameObject.transform.position.y * heightKoeff,
			gameObject.transform.position.z);
	}
}
