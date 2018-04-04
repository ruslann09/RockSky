using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysRespawn : MonoBehaviour {
	public float timeToResp = 5.0f;
	private float timer = 0.0f;
	public GameObject enemyPrefab;
	public Transform maxPosition;
	public int maxCount = 10;
	private List<GameObject> rocks;

	void Start () {
		rocks = new List<GameObject> ();
		timeToResp = Random.Range (timeToResp/2, timeToResp + (timeToResp*2)/5);
		timer = Random.Range (timeToResp/5, timeToResp/3);
	}

	void Update () {
		if (timer >= timeToResp) {
			GameObject spaceRock = Instantiate (enemyPrefab, new Vector3 (transform.position.x * Random.Range (0.8f, 1f), 
				transform.position.y * Random.Range (0.8f, 1f), transform.position.z * Random.Range (0.8f, 1f)), 
				new Quaternion (enemyPrefab.transform.rotation.x * Random.Range (1f, 2f), enemyPrefab.transform.rotation.y * Random.Range (1f, 2f),
					enemyPrefab.transform.rotation.z * Random.Range (1f, 2f), enemyPrefab.transform.rotation.z * Random.Range (1f, 2f)));
			spaceRock.transform.localScale *= Random.Range (1f, 4f);

			timer = 0.0f;

			rocks.Add (spaceRock);
		}

		timer += Time.deltaTime;

//		foreach (GameObject rock in rocks)
//			if (Mathf.Sqrt (Mathf.Pow (rock.transform.position.x, 2) + Mathf.Pow (rock.transform.position.z, 2)) <=
//			    Mathf.Sqrt (Mathf.Pow (maxPosition.transform.position.x, 2) + Mathf.Pow (maxPosition.transform.position.z, 2))) {
//				Destroy (rock);
//				rocks.Remove (rock);
//			}
	}
}
