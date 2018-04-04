using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Transform playerHead, lastPlayerHead;
	public float rayLength = 10, maxHeight, maxForward, speed = 1.0f;
	public Weapoon weapoon;
	public GameObject circleLoading;
	private float shootTimer = 0.0f;
	private WaitForSeconds lineRendererVisibillityTime, wayPointCreatingTime;
	private ImageProgressBar imgProgressBar;
	private Coroutine waiting;
	private bool isStarting = false;

	private void Start () {
		weapoon.Init ();
		lineRendererVisibillityTime = new WaitForSeconds (weapoon.fireRate * 0.8f);
		wayPointCreatingTime = new WaitForSeconds (speed);
		lastPlayerHead = playerHead;
		maxHeight += transform.position.y;
	}

	private void Update () {
		Raycast ();

		shootTimer += Time.deltaTime;
	}

	private void Raycast () {
		Ray ray = new Ray (playerHead.position, playerHead.forward);
		RaycastHit rayHit;

		Debug.DrawRay (playerHead.position, playerHead.forward * rayLength, Color.white, 0.1f);

		if (Physics.Raycast (ray, out rayHit)) {
			if (rayHit.collider.gameObject.CompareTag ("EnemyTarget") && shootTimer >= weapoon.fireRate) {
				rayHit.collider.gameObject.GetComponent<BindEnemyToPlayer> ().enabled = false;
				Destroy (rayHit.collider.gameObject, 5f);
				MakeShot (rayHit.collider.GetComponent<Rigidbody> (), rayHit);
				return;
			} else if (rayHit.collider.gameObject.CompareTag ("WalkingTarget") && shootTimer >= weapoon.fireRate)
				MakeWalkingTargetShot (rayHit.collider.gameObject, rayHit);
			else if (rayHit.collider.gameObject.CompareTag ("collectionitem")) {
				StartCoroutine (CollectionTargetFinding (rayHit));
			}
			else if (rayHit.collider.gameObject.CompareTag ("VR_UI")) {
				imgProgressBar = rayHit.collider.gameObject.GetComponent<ImageProgressBar> ();
				imgProgressBar.GazeOver = true;	
				imgProgressBar.StartFillingProgressBar ();

				return;
			} else if (imgProgressBar != null) {
				imgProgressBar.GazeOver = false;
				imgProgressBar.StopFillingProgressBar ();
				imgProgressBar = null;

				return;
			} else if (rayHit.collider.gameObject.CompareTag ("Floor")) {
				Debug.Log (playerHead.rotation + " " + lastPlayerHead.rotation);
				if ((rayHit.point.x - playerHead.transform.position.x) * (rayHit.point.x - playerHead.transform.position.x) < maxForward
					&& (rayHit.point.z - playerHead.transform.position.z) * (rayHit.point.z - playerHead.transform.position.z) < maxForward
					&& (rayHit.point.y - playerHead.transform.position.y) * (rayHit.point.y - playerHead.transform.position.y) < maxForward
					&& rayHit.point.y < maxHeight)
				waiting = StartCoroutine (WayPointing (rayHit));

				return;
			}
		}
			
	}

	private void MakeShot (Rigidbody targetRb, RaycastHit rayHit) {
		weapoon.Shoot (rayHit.point, -rayHit.normal, targetRb);
		shootTimer = 0.0f;
		StartCoroutine (HandleLineRenderer ());
	}

	private void MakeWalkingTargetShot (GameObject targetGo, RaycastHit rayHit) {
		weapoon.ShootWalkingTarget (rayHit.point, -rayHit.normal, targetGo);
		shootTimer = 0.0f;
		StartCoroutine (HandleLineRenderer ());
	}

	private IEnumerator HandleLineRenderer () {
		yield return lineRendererVisibillityTime;
		weapoon.ClearShootTrace ();
	}

	private IEnumerator WayPointing (RaycastHit rayHit) {
//		if (playerHead.rotation.x == playerPosition.rotation.x && playerHead.rotation.y == playerPosition.rotation.y && playerHead.rotation.z == playerPosition.rotation.z && isStarting)
//			StopCoroutine (waiting);
		yield return wayPointCreatingTime;
		circleLoading.transform.position = new Vector3 (rayHit.point.x, rayHit.point.y + 0.05f, rayHit.point.z);
		//circleLoading.transform.rotation = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
		lastPlayerHead.rotation = playerHead.rotation;
		isStarting = true;
	}

	private IEnumerator CollectionTargetFinding (RaycastHit rayHit) {
		rayHit.collider.gameObject.GetComponent<BoxCollider> ().enabled = false;
		rayHit.collider.gameObject.GetComponent<AudioSource> ().Play ();
//		GameObject target = rayHit.collider.gameObject.transform.parent;
//		target.transform.Find ("PerfectFinding").gameObject.SetActive (true);
		Destroy (rayHit.collider.gameObject, 2.0f);
		yield return null;
	}
}
