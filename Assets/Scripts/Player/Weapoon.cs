using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapoon {
	public float fireRate = 0.1f, shootForce = 10.0f;
	public Transform gunEnd;
	public AudioSource shootAudio;
	public LineRenderer projectileLineRenderer;
		
	public void Init () {
		projectileLineRenderer.positionCount = 2;
	}

	public void Shoot (Vector3 shootPoint, Vector3 force, Rigidbody targetRb) {
		projectileLineRenderer.enabled = true;
		projectileLineRenderer.SetPosition (0, gunEnd.position);
		projectileLineRenderer.SetPosition (1, shootPoint);

		shootAudio.Play ();
		targetRb.AddForceAtPosition (force * shootForce, shootPoint);
	}

	public void ShootWalkingTarget (Vector3 shootPoint, Vector3 force, GameObject targetGo) {
		projectileLineRenderer.enabled = true;
		projectileLineRenderer.SetPosition (0, gunEnd.position);
		projectileLineRenderer.SetPosition (1, shootPoint);

		shootAudio.Play ();
		//targetGo.GetComponent<WalkingTarget> ().TakeDamage ();
	}

	public void ClearShootTrace () {
		projectileLineRenderer.enabled = false;
	}
}
