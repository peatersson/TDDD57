using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour {
	Animator anim;
	GameObject cam;
	bool isHit = false;
	int hitCounter = 0;

  void Start(){
    anim = gameObject.GetComponent<Animator>();
		cam = GameObject.Find("ARCamera");
  }

  void Update(){
		if (isHit){
			if (hitCounter == 10){
				anim.SetTrigger("Dead");
			} else {
				anim.SetTrigger("GetHit");
			}
			isHit = false;
		} else {
			if (Vector3.Distance(transform.position, cam.transform.position) < 1.0){
	      anim.SetTrigger("IsInProximity");
	    } else {
				anim.SetTrigger("IsFarAway");
			}
		}
  }

	public void IsHit(){
		isHit = true;
		hitCounter++;
	}
}
