using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingBilboard : MonoBehaviour {
	private Transform camera;

	private void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera").transform;
	}

	private void Update () {
		transform.LookAt (camera);
	}
}
