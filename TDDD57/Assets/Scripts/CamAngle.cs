using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAngle : MonoBehaviour {
	GameObject cam;

	// Use this for initialization
	void Start () {
    cam = GameObject.Find("ARCamera");
  }

	// Update is called once per frame
	void Update () {
		Vector3 targetDir = cam.transform.position - transform.position;
		float angle = Vector3.Angle(targetDir, transform.forward);
	}
}
