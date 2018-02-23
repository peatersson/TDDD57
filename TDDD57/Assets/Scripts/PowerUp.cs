using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	GameObject powerUp;
	GameObject cam;

	bool isActive = false;
	string[] effects = {"Health", "Buff1", "Buff2", "Buff3"};
	string currentEffect;

	void Start () {
		powerUp = GameObject.Find("PowerUp");
		InvokeRepeating("SpawnRandomPowerUp", 10f, 10f);
		cam = GameObject.Find("ARCamera");

		//powerUp.SetActive(false);
	}

	void Update () {
	}

	void SpawnRandomPowerUp(){
		// Generates a random position in the outskirts of the playing field
		// also tilts the powerup at a random angle, making the game a bit more alive
		int quadrant = Random.Range(1,4);
		Vector3 newPos;
		if (!isActive){
			switch (quadrant){
				case 1:
					newPos = new Vector3(Random.Range(-4f, -2f), -cam.transform.position.y, Random.Range(-4f, 4f));
					break;
				case 2:
					newPos = new Vector3(Random.Range(-4f, 4f), -cam.transform.position.y, Random.Range(2f, 4f));
					break;
				case 3:
					newPos = new Vector3(Random.Range(2f, 4f), -cam.transform.position.y, Random.Range(-4f, 4f));
					break;
				default:
					newPos = new Vector3(Random.Range(-4f, 4f), -cam.transform.position.y, Random.Range(-4f, -2f));
					break;
			}
			powerUp.transform.position = newPos;
			powerUp.transform.rotation = Random.rotation;
			currentEffect = "Health";
			powerUp.SetActive(true);
			isActive = true;
		}
	}

	public string GetEffect(){
		return currentEffect;
	}

	public void Clicked(){
		isActive = false;
		powerUp.SetActive(false);
		currentEffect = "";
	}
}
