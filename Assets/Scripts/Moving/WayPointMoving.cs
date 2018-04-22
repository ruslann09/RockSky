using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMoving : MonoBehaviour {
	public Transform player;

	public void moveToWayPoint () {
		Transform mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		Transform sideBar = null;

		if (GameObject.FindGameObjectWithTag ("SideBar") != null)
			sideBar = GameObject.FindGameObjectWithTag ("SideBar").transform;

		//sideBar.rotation = new Quaternion (sideBar.rotation.x, mainCamera.rotation.y, sideBar.rotation.z, sideBar.rotation.w);

		if (sideBar != null && mainCamera != null) {
			if (mainCamera.rotation.y > sideBar.rotation.z && mainCamera.rotation.y > 0)
				sideBar.Rotate (0f, 0f, -Mathf.Abs (mainCamera.rotation.y - sideBar.rotation.z) * 100);
			else if (mainCamera.rotation.y < sideBar.rotation.z && mainCamera.rotation.y > 0)
				sideBar.Rotate (0f, 0f, -Mathf.Abs (sideBar.rotation.z - mainCamera.rotation.y) * 100);
			else if (mainCamera.rotation.y > sideBar.rotation.z && mainCamera.rotation.y < 0)
				sideBar.Rotate (0f, 0f, (Mathf.Abs (sideBar.rotation.z) - Mathf.Abs (mainCamera.rotation.y)) * 100);
			else if (mainCamera.rotation.y < sideBar.rotation.z && mainCamera.rotation.y < 0)
				sideBar.Rotate (0f, 0f, (Mathf.Abs (mainCamera.rotation.y) - Mathf.Abs (sideBar.rotation.z)) * 100);
		}

		player.transform.position = new Vector3 (transform.position.x, transform.position.y + 1.8f, transform.position.z);
	}
}
