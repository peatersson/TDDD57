using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	RaycastHit hit;
	Ray ray;
	GameObject fighter;
	Fighter fighter_script;
	GameObject healthBar;
	HealthBar healthBar_script;
	ManaBar manaBar_script;
	GameObject powerUp;
	PowerUp powerUp_script;
	GameObject hp_canvas;
	IndicateDamage hp_canvas_script;
	GameObject left_indicate;
	GameObject right_indicate;

	int maxHealth = 400;
	int maxMana = 400;
	int currentHealth;
	int damage = 50;
	string currentEffect;
	bool isDead = false;
	bool rotateLeft;
	bool isPowerUpActive;

	void Start(){
		fighter = GameObject.Find("littleswordfighter");
		fighter_script = fighter.GetComponent<Fighter>();
		healthBar = GameObject.Find("HealthBarCanvas");
		healthBar_script = healthBar.GetComponent<HealthBar>();
		manaBar_script = healthBar.GetComponent<ManaBar>();
		powerUp = GameObject.Find("PowerUp");
		powerUp_script = powerUp.GetComponent<PowerUp>();
		hp_canvas = GameObject.Find("HealthBarCanvas");
		hp_canvas_script = hp_canvas.GetComponent<IndicateDamage>();
		left_indicate = GameObject.Find("LeftIndication");
		right_indicate = GameObject.Find("RightIndication");

		currentHealth = maxHealth;
	}

	void Update(){
		if (!isDead){
			// Look for touch-event and generate click
			Click();
			IndicatePowerUp();
		}
	}

	void Click(){
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

	  if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0)){
			switch (hit.collider.gameObject.name){
				case "FighterHitBox":
					if (Vector3.Distance(transform.position, fighter.transform.position) < 3.0){
						fighter = hit.collider.transform.parent.gameObject;
						fighter_script.TakeDamage(manaBar_script.GetMana(damage));
					}
					break;
				case "PowerUp":
					HandlePowerUp(powerUp_script.GetEffect());
					powerUp_script.Clicked();
					break;
				default:
					break;
			}
		}
	}

	public void TakeDamage(int damageTaken){
		if (!isDead){
			currentHealth -= damageTaken;

			if (currentHealth <= 0){
				currentHealth = 0;
				isDead = true;
				fighter_script.Victorious();
			}

			healthBar_script.TakeDamage(damageTaken);
			if (damageTaken > 0){
				IndicateDamage();
			}
		}
	}

	void HandlePowerUp(string effect){
		switch (effect){
			case "Health":
				Heal(50);
				break;
		}
	}

	void Heal(int amount){
		if (currentHealth + amount > maxHealth){
			TakeDamage(currentHealth-maxHealth);
		} else {
			TakeDamage(-amount);
		}
	}

	void IndicateDamage(){
		hp_canvas_script.FlashDamage();
	}

	void IndicatePowerUp(){
		if (isPowerUpActive && !powerUp.GetComponent<MeshRenderer>().isVisible){
			float anglePowerUp = (Mathf.Atan2(powerUp.transform.position.x, powerUp.transform.position.z) / Mathf.PI) * 180f;
			float anglePlayer = (Mathf.Atan2(transform.position.x, transform.position.z) / Mathf.PI) * 180f;
			float fighterToPowerUp = Vector3.Distance(fighter.transform.position, powerUp.transform.position);
			float fighterToPlayer = Vector3.Distance(fighter.transform.position, transform.position);

			if (anglePowerUp > (anglePlayer + 180)%360){
				rotateLeft = true;
			} else {
				rotateLeft = false;
			}

			SetIndication();

		} else {
			left_indicate.SetActive(false);
			right_indicate.SetActive(false);
		}
	}

	public void SetIndication(){
		if (rotateLeft){
			if (!left_indicate.activeSelf){
				left_indicate.SetActive(true);
			}
			right_indicate.SetActive(false);
		} else {
			if (!right_indicate.activeSelf){
				right_indicate.SetActive(true);
			}
			left_indicate.SetActive(false);
		}
	}

	public void SetPowerUp(bool status){
		isPowerUpActive = status;
	}
}

/*
TODO:
- finjustera skada/liv osv
- spara en version där vi tar lite/inge damage
*/
