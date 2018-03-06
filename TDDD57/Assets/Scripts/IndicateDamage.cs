using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicateDamage : MonoBehaviour {
	GameObject left;
	GameObject right;
	GameObject upper;
	GameObject lower;
	Color red = Color.red;
	Color green = Color.green;
	Color current;

	bool isActive = false;
	float factor = (float)10/(float)255;

	void Start () {
		left = GameObject.Find("LeftFlash");
		left.SetActive(false);
		right = GameObject.Find("RightFlash");
		right.SetActive(false);
		upper = GameObject.Find("UpperFlash");
		upper.SetActive(false);
		lower = GameObject.Find("LowerFlash");
		lower.SetActive(false);
	}

	void Update () {
		if (isActive){
			left.GetComponent<Image>().color = new Color(current.r, current.g, current.b, current.a - factor);
			right.GetComponent<Image>().color = new Color(current.r, current.g, current.b, current.a - factor);
			upper.GetComponent<Image>().color = new Color(current.r, current.g, current.b, current.a - factor);
			lower.GetComponent<Image>().color = new Color(current.r, current.g, current.b, current.a - factor);

			current = left.GetComponent<Image>().color;
		}
	}

	public void FlashDamage(){
		StartCoroutine(Flash(red));
	}

	public void FlashHeal(){
	}

	IEnumerator Flash(Color color){
		isActive = true;
		left.SetActive(true);
		left.GetComponent<Image>().color = color;
		right.SetActive(true);
		right.GetComponent<Image>().color = color;
		upper.SetActive(true);
		upper.GetComponent<Image>().color = color;
		lower.SetActive(true);
		lower.GetComponent<Image>().color = color;
		current = color;

		yield return new WaitForSeconds(0.5f);

		left.SetActive(false);
		right.SetActive(false);
		upper.SetActive(false);
		lower.SetActive(false);
		isActive = false;
	}
}
