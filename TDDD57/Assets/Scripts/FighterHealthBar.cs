using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterHealthBar : MonoBehaviour {
	public const int maxHealth = 400;
	public int currentHealth;
	public Transform healthBar;
	bool isZero = false;
	int counter = 0;

	void Start () {
		currentHealth = maxHealth;
	}

	void Update () {
	}

	public void TakeDamage(int amount){
		Transform tf = healthBar.transform;

		currentHealth -= amount;
		if (currentHealth <= 0){
			// dead
			currentHealth = 0;
			isZero = true;
		}

		healthBar.transform.localScale = new Vector3(tf.localScale.x - amount*2/400f, tf.localScale.y, tf.localScale.z);
	}
}
