using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
	float currentAngleInRadian;
	float oneDegreeInRadian;
	public bool direction;

	// Use this for initialization
	void Start () {
		currentAngleInRadian = 0;
		oneDegreeInRadian = Mathf.PI/180;
		direction = true;
	}

	// Update is called once per frame
	void Update () {
		if (direction){
			currentAngleInRadian += 0.5f*oneDegreeInRadian;
		} else {
			currentAngleInRadian -= 0.5f*oneDegreeInRadian;
		}

		transform.position = new Vector3( Mathf.Cos(currentAngleInRadian), // x-pos
																			(float)1, // y-pos
																			Mathf.Sin(currentAngleInRadian)); // z-pos

		if (direction){
			if (currentAngleInRadian >= 2*Mathf.PI){
				currentAngleInRadian = 0;
			}
		} else {
			if (currentAngleInRadian <= 0){
				currentAngleInRadian = 2*Mathf.PI;
			}
		}

	}
}
