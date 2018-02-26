using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	GameObject powerUp;
	GameObject cam;
	Player player_script;

	bool isActive = false;
	string currentEffect;

	void Start () {
		powerUp = GameObject.Find("PowerUp");
		InvokeRepeating("SpawnRandomPowerUp", 10f, 10f);
		cam = GameObject.Find("ARCamera");
		player_script = cam.GetComponent<Player>();

		//powerUp.SetActive(false);
	}

	void Update () {
	}

	void SpawnRandomPowerUp(){
		// Generates a random position in the outskirts of the playing field
		// also tilts the powerup at a random angle, making the game a bit more alive
		int quadrant = Random.Range(1,5);
		Vector3 newPos;
		if (!isActive){
			switch (quadrant){
				case 1:
					newPos = new Vector3(Random.Range(-6f, -4f), -cam.transform.position.y, Random.Range(-6f, 6f));
					break;
				case 2:
					newPos = new Vector3(Random.Range(-6f, 6f), -cam.transform.position.y, Random.Range(4f, 6f));
					break;
				case 3:
					newPos = new Vector3(Random.Range(4f, 6f), -cam.transform.position.y, Random.Range(-6f, 6f));
					break;
				default:
					newPos = new Vector3(Random.Range(-6f, 6f), -cam.transform.position.y, Random.Range(-6f, -6f));
					break;
			}
			powerUp.transform.position = newPos;
			powerUp.transform.rotation = Random.rotation;
			currentEffect = "Health";
			powerUp.SetActive(true);
			isActive = true;
			player_script.SetPowerUp(true);
		}
	}

	public string GetEffect(){
		return currentEffect;
	}

	public void Clicked(){
		isActive = false;
		powerUp.SetActive(false);
		player_script.SetPowerUp(false);
		currentEffect = "";
	}
}
