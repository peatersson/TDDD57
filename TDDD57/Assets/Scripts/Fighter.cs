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

	float maxHealth = 400;
	float currentHealth;
	int damage = 5;
	bool isAttacking = false;
	float distanceToPlayer;
	bool isDead;
	bool isVictorious;

	void Start () {
		cam = GameObject.Find("ARCamera");
		player_script = cam.GetComponent<Player>();
		healthBar = GameObject.Find("Cube");
		hp_script = healthBar.GetComponent<FighterHealthBar>();
		fighter = GameObject.Find("littleswordfighter");
		anim_script = fighter.GetComponent<AnimScript>();
		damage_script = GameObject.Find("Canvas").GetComponent<DamageText>();
		isDead = false;
		isVictorious = false;

		currentHealth = maxHealth;
	}

	void Update () {
		distanceToPlayer = Vector3.Distance(transform.position, cam.transform.position);

		if (!isDead && !isVictorious){
			// make the fighter look so that he faces the player
			LookAtPlayer();

			// check for Attack
			CheckForAttack();
		}
	}

	void CheckForAttack(){
		if (!isAttacking){
			if (distanceToPlayer < 3.0 && distanceToPlayer != 0){
				anim_script.Attack();
				InvokeRepeating("Attack", 1.4f, 1.4f);
				isAttacking = true;
			} else {
				CancelInvoke("Attack");
				anim_script.Taunt();
			}
		} else {
			if (distanceToPlayer > 4.0 && distanceToPlayer != 0){
				CancelInvoke("Attack");
				anim_script.Taunt();
				isAttacking = false;
			} else{
				anim_script.Attack();
			}
		}
		/*if (distanceToPlayer < 2.0 && distanceToPlayer != 0 || isAttacking){
			anim_script.Attack();

			if (!isAttacking){
				InvokeRepeating("Attack", 1.4f, 1.4f);
				isAttacking = true;
			}
		} else {
			CancelInvoke("Attack");
			anim_script.Taunt();
			isAttacking = false;
		}*/
	}

	void LookAtPlayer(){
		Vector3 pos = cam.transform.position;
		pos[1] = pos[1] / 2f;
		transform.LookAt(pos);
	}

	void Attack(){
		if (isAttacking){
			player_script.TakeDamage(damage);
		}
	}

	public void Victorious(){
		anim_script.Victorious();
		isVictorious = true;
	}

	public void TakeDamage(float damageTaken){
		if (!isDead){
			currentHealth -= damageTaken;
			hp_script.TakeDamage(damageTaken);
			damage_script.TextActive(damageTaken);

			if(currentHealth <= 0){
				anim_script.Dead();
				isDead = true;
			}
		}
	}
}
