using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlane : MonoBehaviour {
	GameObject cam;
	GameObject firePlane;
	Player player_script;

	float angle;
	int damage = 10;
	bool isActive = false;

	// Use this for initialization
	void Start () {
		cam = GameObject.Find("ARCamera");
		firePlane = GameObject.Find("FirePlane");
		player_script = cam.GetComponent<Player>();

		InvokeRepeating("ChangePosition", 10f, 10f);
		firePlane.SetActive(false);
	}

	void Update () {
	}

	void ChangePosition(){
		if (!isActive){
			firePlane.SetActive(true);
			isActive = true;
			angle = Random.Range(-2*Mathf.PI, 2*Mathf.PI);

			transform.position = new Vector3(0.5f*cam.transform.position.x, 0, 0.5f*cam.transform.position.z);
			InvokeRepeating("CauseDamage", 0f, 0.2f);
		} else {
			isActive = false;
			firePlane.SetActive(false);
			CancelInvoke("CauseDamage");
		}
	}

	void CauseDamage(){
		Vector3 player_temp = cam.transform.position;
		player_temp[1] = transform.position.y;
		if (Vector3.Distance(player_temp, transform.position) < 1){
			player_script.TakeDamage(damage);
		}
	}
}
