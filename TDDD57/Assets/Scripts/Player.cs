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

	int maxHealth = 400;
	int maxMana = 400;
	int currentHealth;
	int damage = 10;
	string currentEffect;
	bool isDead = false;

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

		currentHealth = maxHealth;
	}

	void Update(){
		// generate click
		Click();
	}



	void Click(){
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

	  if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0)){
			switch (hit.collider.gameObject.name){
				case "FighterHitBox":
					if (Vector3.Distance(transform.position, fighter.transform.position) < 2.0){
						fighter = hit.collider.transform.parent.gameObject;
						int manaLevel = manaBar_script.GetMana(damage);
						fighter_script.TakeDamage(manaLevel);
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
				isDead = false;
			}

			healthBar_script.TakeDamage(damageTaken);
			IndicateDamage();
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
}

/*
TODO:
- Visa skada tagen för spelaren
- Hantering av när riddaren dör
- Hantering av när spelaren dör

- finjustera skada/liv osv
- elden ska spawna på oss
- fixa manareg
- extended tracking
*/
