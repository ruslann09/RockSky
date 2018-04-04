using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometsRunning : MonoBehaviour {
	public float speed, size;

	private void Start () {
		speed = Random.Range (0.1f, 0.3f);
		size = Random.Range (3, 15);
		transform.localScale = new Vector3 (transform.localScale.x*size, transform.localScale.y*size, transform.localScale.z*size);
	}

	private void Update () {
		transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
	}
}
