using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicateDamage : MonoBehaviour {
	GameObject left;
	GameObject right;
	GameObject upper;
	GameObject lower;

	bool isFlashing = false;

	// Use this for initialization
	void Start () {
		left = GameObject.Find("LeftFlash");
		right = GameObject.Find("RightFlash");
		upper = GameObject.Find("UpperFlash");
		lower = GameObject.Find("LowerFlash");
	}

	// Update is called once per frame
	void Update () {
		if (isFlashing){
			right.GetComponent<Image>().color = Color.Lerp(Color.red, Color.clear, Mathf.PingPong(Time.time, 1));
		} else {
			right.GetComponent<Image>().color = Color.clear;
		}
	}

	public void FlashDamage(){
		isFlashing = true;
		InvokeRepeating("Flash", 1f, 1f);
	}

	public void FlashHeal(){
		right.GetComponent<Image>().color = Color.Lerp(Color.green, Color.clear, 0.5f);
	}

	void Flash(){
		isFlashing = false;
		CancelInvoke("Flash");
	}
}
