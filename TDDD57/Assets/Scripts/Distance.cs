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
    float tempDistance = Vector3.Distance(cam.transform.position, transform.position);

    if (tempDistance < 2){
      GetComponent<SkinnedMeshRenderer>().material.color = Color.white;
    } else if (tempDistance > 4){
      GetComponent<SkinnedMeshRenderer>().material.color = Color.black;
		} /*else {
      GetComponent<SkinnedMeshRenderer>().material.color = Color.black;
    }*/
	}
}
