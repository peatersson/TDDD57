using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Distance : MonoBehaviour {
    GameObject cam;

	// Use this for initialization
	void Start () {
        cam = GameObject.Find("ARCamera");
    }

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(cam.transform.position, transform.position) > 0.5){
			GetComponent<SkinnedMeshRenderer>().material.color = Color.black;
		} else {
			GetComponent<SkinnedMeshRenderer>().material.color = Color.white;
		}
  	Debug.Log(Vector3.Distance(cam.transform.position, transform.position));
		//Debug.Log("color: " + GetComponent<Renderer>().material.color);
		Debug.Log("Cam: " + cam.transform.position);
	}
}
