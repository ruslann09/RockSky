using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindEnemyToPlayer : MonoBehaviour {
	private Transform WhereToFocus;
	public float speed = 0.1f;
	private float timer = 0f;

	void Start () {
		WhereToFocus = GameObject.FindGameObjectWithTag ("Player").transform;
		speed = 1 / speed;
	}

	void Update () {
		if (timer >= speed) {
			Vector3 pos = new Vector3 ();

			if (Mathf.Abs (WhereToFocus.position.z - transform.position.z) > 2) {
				if (WhereToFocus.position.z > transform.position.z)
					pos.z = transform.position.z + speed;
				else if (WhereToFocus.position.z < transform.position.z)
					pos.z = transform.position.z - speed;
			}

			if (Mathf.Abs (WhereToFocus.position.x - transform.position.x) > 2) {
				if (WhereToFocus.position.x > transform.position.x)
					pos.x = transform.position.x + speed;
				else if (WhereToFocus.position.x < transform.position.x)
					pos.x = transform.position.x - speed;
			}

			if (Mathf.Abs (WhereToFocus.position.y - transform.position.y) > 2) {
				if (WhereToFocus.position.y > transform.position.y)
					pos.y = transform.position.y + speed;
				else if (WhereToFocus.position.y < transform.position.y)
					pos.y = transform.position.y - speed;
			}

			transform.position = pos;

			timer = 0f;
		}

		timer += Time.deltaTime;
	}
}
