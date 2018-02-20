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

	int maxHealth = 400;
	int maxMana = 400;
	int currentHealth;
	int damage = 5;
	string currentEffect;

	void Start(){
		fighter = GameObject.Find("littleswordfighter");
		fighter_script = fighter.GetComponent<Fighter>();
		healthBar = GameObject.Find("HealthBarCanvas");
		healthBar_script = healthBar.GetComponent<HealthBar>();
		manaBar_script = healthBar.GetComponent<ManaBar>();
		powerUp = GameObject.Find("PowerUp");
		powerUp_script = powerUp.GetComponent<PowerUp>();

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
					fighter = hit.collider.transform.parent.gameObject;
					int manaLevel = manaBar_script.GetMana(damage);
					fighter_script.SetRegisteredHit(true, manaLevel);
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
		currentHealth -= damageTaken;
		healthBar_script.TakeDamage(damageTaken);
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

	}
}

/*
TODO:
- Bättre slumpplacering för powerup - check
- Storlek/vinkel för powerup - check
- Annorlunda bilder för powerup - check (heal)

- Zoneffekter - check
- Slumpa vilken Zon - check
- Längd för skada - check

- Random attackanimation för riddaren
- Visa skada tagen för riddaren
- Visa skada tagen för spelaren
- Hantering av när riddaren dör
- Hantering av när spelaren dör

- cooldown för spelarslag
- visuellt visa cooldown
*/
