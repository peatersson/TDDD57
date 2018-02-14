using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautClick : MonoBehaviour {
	RaycastHit hit;
	Ray ray;
	Orbit o_script;

	void Start(){
		o_script = GameObject.Find("Sphere").GetComponent<Orbit>();
	}

	void Update(){
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

	  if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0)){
			switch (hit.collider.gameObject.name){
				case "HitBox":
					hit.collider.transform.parent.Rotate(Vector3.up * 90f);
					break;
				case "Sphere":
					o_script.direction = !o_script.direction;
					break;
				default:
					break;
			}
		}
	}
}
