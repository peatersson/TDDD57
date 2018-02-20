using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingText : MonoBehaviour {

	Vector3 newPos;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		newPos[1] += 0.1f;
		transform.position = newPos;
	}
}
