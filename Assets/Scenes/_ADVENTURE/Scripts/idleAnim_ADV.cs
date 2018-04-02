using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleAnim_ADV : MonoBehaviour {

	public Sprite sp1;
	public Sprite sp2;
	float duration = 0.0f;
	float timer = 0.0f;

	bool turnChange = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		duration = Random.Range (1.5f, 4);
		timer += 1 * Time.deltaTime;

		if (timer >= duration) {
			if (this.GetComponent<SpriteRenderer> ().sprite == sp1 && turnChange) {
				this.GetComponent<SpriteRenderer> ().sprite = sp2;
				turnChange = false;
			}
			if (this.GetComponent<SpriteRenderer> ().sprite == sp2 && turnChange) {
				this.GetComponent<SpriteRenderer> ().sprite = sp1;
				turnChange = false;
			}

			turnChange = true;
			timer = 0.0f;
		}
	}
}
