using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterClick : MonoBehaviour {
	RaycastHit hit;
	Ray ray;
	AnimScript anim_script;
	GameObject fighter;

	void Start(){
	}

	void Update(){
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

	  if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0)){
			switch (hit.collider.gameObject.name){
				case "HitBox":
					Debug.Log("IsHit");
					fighter = hit.collider.transform.parent.gameObject;
					anim_script = fighter.GetComponent<AnimScript>();
					anim_script.IsHit();
					break;
				default:
					break;
			}
		}
	}
}
