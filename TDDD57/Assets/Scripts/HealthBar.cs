using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
	public const int maxHealth = 400;
	public int currentHealth = maxHealth;
	public RectTransform healthBar;

	void Start () {

	}

	void Update () {
	}

	public void TakeDamage(int amount){
		Transform tf = healthBar.transform;

		currentHealth -= amount;
		if (currentHealth <= 0)
		{
				currentHealth = 0;
		}

		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
		healthBar.transform.position = new Vector3(tf.position.x - (amount/2f), tf.position.y, tf.position.z);
	}
}
