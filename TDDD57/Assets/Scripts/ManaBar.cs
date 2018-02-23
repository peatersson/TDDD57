using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour {
	public RectTransform manaBar;
	public const int maxMana = 400;
	public int currentMana = maxMana;
	// Use this for initialization
	void Start () {
		InvokeRepeating("TickMana", 0f, 0.01f);
	}

	// Update is called once per frame
	void Update () {

	}

	void TickMana(){
		if (currentMana < maxMana){
			Transform tf = manaBar.transform;

			currentMana++;
			manaBar.sizeDelta = new Vector2(currentMana, manaBar.sizeDelta.y);
			manaBar.transform.position = new Vector3(tf.position.x + (0.5f), tf.position.y, tf.position.z);
		}
	}

	public int GetMana(int damage){
		Transform tf = manaBar.transform;

		int returnValue = (int)Mathf.Ceil((float)damage*(float)currentMana/(float)maxMana);
		manaBar.sizeDelta = new Vector2(currentMana, manaBar.sizeDelta.y);
		manaBar.transform.position = new Vector3(tf.position.x - (currentMana/2f), tf.position.y, tf.position.z);
		currentMana = 0;
		return returnValue;
	}
}
