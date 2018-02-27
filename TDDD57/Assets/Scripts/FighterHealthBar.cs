using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterHealthBar : MonoBehaviour {
	public const float maxHealth = 400;
	public float currentHealth;
	public Transform healthBar;
	GameObject cube;
	GameObject cubeCore;
	bool isZero = false;

	void Start () {
		currentHealth = maxHealth;
		cube = GameObject.Find("Cube");
		cubeCore = GameObject.Find("CubeCore");
	}

	void Update () {
	}

	public void TakeDamage(float amount){
		Transform tf = healthBar.transform;

		currentHealth -= amount;
		if (currentHealth <= 0){
			// dead
			currentHealth = 0;
			isZero = true;
			cube.SetActive(false);
			cubeCore.SetActive(false);
		}
		if(!isZero){
			healthBar.transform.localScale = new Vector3(tf.localScale.x - amount*2/400f, tf.localScale.y, tf.localScale.z);
		}
	}
}
