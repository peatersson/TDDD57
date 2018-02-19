using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour {

	GameObject cam;
	GameObject txt;
	GameObject fighter;
	int stability_counter = 0;
	int active_timer = 0;
	public Text txtRef;
	Vector3 newPos;

	// Use this for initialization
	void Start () {
		cam = GameObject.Find("ARCamera");
		txtRef = GameObject.Find("Text").GetComponent<Text>();
		fighter = GameObject.Find("littleswordfighter");
	}

	// Update is called once per frame
	void Update () {
		FadeUp();
		DeactivateText();
	}

	void FadeUp(){
		newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		newPos[1] += 0.1f;
		transform.position = newPos;
	}

	void DeactivateText(){
		active_timer++;
		if (active_timer == 300){
			txtRef.text = "";
			active_timer = 0;
		}
	}

	/*void StabilizeText(){
		stability_counter++;
		if (stability_counter == 30){ //To avoid shaky text
			transform.position = new Vector3(cam.transform.position.x/2, cam.transform.position.y/2, cam.transform.position.z/2);
			transform.LookAt(cam.transform.position);
			stability_counter = 0;
		}
	}*/

	public void TextActive(int damage){
		txtRef.text = "" + damage;
		active_timer = 0;
		transform.position = new Vector3(0, 0.5f, 0);
		transform.LookAt(cam.transform.position, fighter.transform.up);
	}
}
