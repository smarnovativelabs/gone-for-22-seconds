using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

	public Transform target;

	void Start () {
	}

	void Update () {
		transform.position = new Vector3 (transform.position.x, target.position.y, transform.position.z);
	}
}
