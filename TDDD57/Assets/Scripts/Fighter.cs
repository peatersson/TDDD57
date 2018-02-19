using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {
	GameObject cam;
	GameObject healthBar;
	GameObject fighter;
	FighterHealthBar hp_script;
	AnimScript anim_script;
	Player player_script;
	DamageText damage_script;

	int maxHealth = 400;
	int currentHealth;
	int damage = 25;
	bool registeredHit = false;
	int damageTaken;
	bool isAttacking = false;
	int attackCounter = 0;
	float distanceToPlayer;

	void Start () {
		cam = GameObject.Find("ARCamera");
		player_script = cam.GetComponent<Player>();
		healthBar = GameObject.Find("Cube");
		hp_script = healthBar.GetComponent<FighterHealthBar>();
		fighter = GameObject.Find("littleswordfighter");
		anim_script = fighter.GetComponent<AnimScript>();
		damage_script = GameObject.Find("Canvas").GetComponent<DamageText>();

		currentHealth = maxHealth;
		//InvokeRepeating("Update", 0f, 0.3f);
	}

	void Update () {
		distanceToPlayer = Vector3.Distance(transform.position, cam.transform.position);

		// make the fighter look so that he faces the player
		LookAtPlayer();

		// handle possible hit
		CheckIfHit();

		// check for Attack
		CheckForAttack();
	}

	void CheckIfHit(){
		if (registeredHit){
			anim_script.IsHit();
			//isAttacking = false;
			hp_script.TakeDamage(damageTaken);
			currentHealth -= damageTaken;

			// show damage taken in form of animation
			damage_script.TextActive(damageTaken);
			damageTaken = 0;
			registeredHit = false;
		}
	}

	void CheckForAttack(){
		//Debug.Log("Distance: " + distanceToPlayer);
		if (distanceToPlayer < 2.0 && distanceToPlayer != 0){
			anim_script.Attack();

			if (!isAttacking){
				//InvokeRepeating("Attack", 0.7f, 0.7f);
				isAttacking = true;
			}
		} else {
			//CancelInvoke("Attack");
			anim_script.Taunt();
			attackCounter = 0;
			isAttacking = false;
		}
	}

	void LookAtPlayer(){
		Vector3 pos = cam.transform.position;
		pos[1] = pos[1] / 2f;
		transform.LookAt(pos);
	}

	public void SetRegisteredHit(bool hit, int damage){
		registeredHit = hit;
		damageTaken = damage;
	}

	void Attack(){
		if (isAttacking){
			player_script.TakeDamage(damage);
		}
	}
}
