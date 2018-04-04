using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingTarget : MonoBehaviour {
	private NavMeshAgent navMesh;
	private Transform curDestination;
	public Transform[] wayPoints;
	public AudioSource[] audios;

	private void Start () {
		navMesh = GetComponent<NavMeshAgent> ();

		setRandomNavMeshAgentDestination ();
	}

	private void Update () {
		float dist = navMesh.remainingDistance;

		if (dist != Mathf.Infinity && navMesh.pathStatus == NavMeshPathStatus.PathComplete && navMesh.remainingDistance < 0.1f) {
			if (Random.Range (0, 2) == 1 && audios.Length > 0)
				audios [Random.Range (0, audios.Length)].Play ();
			setRandomNavMeshAgentDestination ();
		}
	}

	private void setRandomNavMeshAgentDestination () {
		int wayPointIndex = Random.Range (0, wayPoints.Length);
		curDestination = wayPoints [wayPointIndex];
		navMesh.SetDestination (curDestination.position);
	}
}
