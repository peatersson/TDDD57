using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterPosition : MonoBehaviour {
	GameObject cam;

	void Start () {
		cam = GameObject.Find("ARCamera");
	}

	void Update () {
		// make the fighter lean so that he faces the player
		LeanAccordingToEnemy();
	}

	void LeanAccordingToEnemy(){
		/*Quaternion newRotation = transform.rotation;
		float radian = -Mathf.Sin((float)cam.transform.position.y /
											Vector3.Distance(cam.transform.position, transform.position));
		newRotation[0] = radian / 2f;
		transform.rotation = newRotation;*/
		Vector3 pos = cam.transform.position;
		pos[1] = pos[1] / 2f;
		transform.LookAt(pos);

	}
}
