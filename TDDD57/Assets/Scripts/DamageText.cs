﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour {

	GameObject cam;
	GameObject txt;

	void Start () {
		txt = GameObject.Find("DamageText");
	}

	void Update () {
	}

	public void TextActive(float damage){
		var textChild = Instantiate (txt, transform);
		textChild.transform.position = new Vector3(0, 0.5f, 0);
		textChild.GetComponent<Text>().text = "" + damage;
		Destroy(textChild, 2f);
	}
}
