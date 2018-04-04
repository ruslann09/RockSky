using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCometsRunning : MonoBehaviour {
	private float currentTime;
	public float timeToResp = 5.0f;
	public int initCometsCount = 4, maxCometsCount = 30;
	private int curCometsCount, localPos;
	public GameObject[] cometPrefab;
	private GameObject[] comets;
	private bool isFull;
	public float maxDistKoeff = 1.1f;

	private void Start () {
		comets = new GameObject[maxCometsCount];

		for (int i = 0; i < initCometsCount; i++)
			comets [localPos] = Instantiate (cometPrefab[Random.Range (0, cometPrefab.Length)], new Vector3 (transform.position.x + Random.Range (20, Mathf.Abs (this.transform.position.x*maxDistKoeff)), 
				transform.position.y + Random.Range (20, 40), 
				transform.position.z + Random.Range (20, 40)), Quaternion.identity);

		curCometsCount = initCometsCount;
	}

	private void Update () {
		if (currentTime >= timeToResp) {
			if (curCometsCount < maxCometsCount) {
				if (isFull)
					comets [localPos] = Instantiate (cometPrefab [Random.Range (0, cometPrefab.Length)], new Vector3 (transform.position.x + Random.Range (1, 10), 
						transform.position.y + Random.Range (1, 10), 
						transform.position.z + Random.Range (1, 10)), cometPrefab [Random.Range (0, cometPrefab.Length)].transform.rotation);
				else if (cometPrefab.Length > 0) {
					comets [curCometsCount] = Instantiate (cometPrefab [Random.Range (0, cometPrefab.Length)], new Vector3 (transform.position.x + Random.Range (1, 10), 
						transform.position.y + Random.Range (1, 10), 
						transform.position.z + Random.Range (1, 10)), cometPrefab [Random.Range (0, cometPrefab.Length)].transform.rotation);
					currentTime = 0.0f;
					curCometsCount++;
				}
			}

			if (curCometsCount == maxCometsCount)
				isFull = true;

			for (int i = 0; i < maxCometsCount; i++)
				if (comets [i] != null && comets [i].transform.position.x >= this.transform.position.x*maxDistKoeff) {
					Destroy (comets [i]);
					comets [i] = null;
					curCometsCount--;
					localPos = i;
				}
		}

		currentTime += Time.deltaTime;
	}
}
