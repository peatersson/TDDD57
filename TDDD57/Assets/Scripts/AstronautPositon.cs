using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautPositon : MonoBehaviour {
	GameObject cam;

	void Start () {
		cam = GameObject.Find("ARCamera");
	}

	void Update () {
		float tempDistance = Vector3.Distance(cam.transform.position, transform.position);

		if (tempDistance > 2 && tempDistance < 4){
			if (transform.position.x > cam.transform.position.x &&
	        transform.position.z > cam.transform.position.z){
	      GetComponent<SkinnedMeshRenderer>().material.color = Color.red;
	    } else if (transform.position.x < cam.transform.position.x  &&
	                transform.position.z > cam.transform.position.z){
	      GetComponent<SkinnedMeshRenderer>().material.color = Color.magenta;
	    } else if (transform.position.x < cam.transform.position.x &&
	                transform.position.z < cam.transform.position.z){
	      GetComponent<SkinnedMeshRenderer>().material.color = Color.cyan;
	    } else {
	      GetComponent<SkinnedMeshRenderer>().material.color = Color.yellow;
	    }
		}
	}
}
