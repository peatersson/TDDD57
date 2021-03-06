﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour {
	Animator anim;

  void Start(){
		anim = gameObject.GetComponent<Animator>();
	}

  void Update(){
		anim.SetInteger("stateRandom", Random.Range(1,4));
  }

	public void IsHit(){
		anim.SetTrigger("GetHit");
	}

	public void Attack(){
		anim.SetTrigger("IsInProximity");
	}

	public void Taunt(){
		anim.SetTrigger("IsFarAway");
	}

	public void Dead(){
		anim.SetTrigger("Dead");
	}

	public void Victorious(){
		anim.SetTrigger("Victory");
	}
}
