using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

	[SerializeField] int index;
	[SerializeField] int total;
	[SerializeField] Transform target;
	float height;

	void Start () {
		height = GetComponent <SpriteRenderer> ().bounds.size.y * transform.localScale.y;
		transform.position = new Vector2 (transform.position.x, transform.position.y + height * index);
	}

	void Update () {
		if (Mathf.Abs (transform.position.y - target.position.y) > (height * total / 2)) {
			transform.position = new Vector2 (transform.position.x, transform.position.y - height * total * Mathf.Sign (transform.position.y - target.position.y));
		}
	}
}
