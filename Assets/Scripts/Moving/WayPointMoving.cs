using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMoving : MonoBehaviour {
	public Transform player;

	public void moveToWayPoint () {
		player.transform.position = new Vector3 (transform.position.x, transform.position.y + 1.8f, transform.position.z);
	}
}
