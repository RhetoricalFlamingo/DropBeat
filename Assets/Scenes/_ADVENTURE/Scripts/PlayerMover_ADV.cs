﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover_ADV : MonoBehaviour {

	float playerSpeed = .0001f;

	Vector3 newPosition = new Vector2 (0, 0);
	private float startTime;
	private float journeyDistance;

	public float moveSpeed = 0;
	bool rStickNeutral;

	public GameObject ABTran;
	bool inBattle = false;

	public GameObject babot;
	public bool nearBabot;
	public GameObject npc1;
	public bool nearNpc1;
	public GameObject npc2;
	public bool nearNpc2;
	public GameObject npc3;
	public bool nearNpc3;

	float distanceCheck = 3f;

	public Sprite front;
	public Sprite back;

	public AudioSource SFX;
	public AudioClip move;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = new Vector3 (transform.position.x, transform.position.y, -4);

		moveSpeed = playerSpeed * Time.deltaTime;

		if (Input.GetAxis ("rJoystickX") < .15f && Input.GetAxis ("rJoystickX") > -.15f && Input.GetAxis ("rJoystickY") < .15f && Input.GetAxis ("rJoystickY") > -.15f) {
			rStickNeutral = true;
		}

		inBattle = ABTran.GetComponent<ABTransition> ().inBattle;

		if (!inBattle) {

			if ((Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetAxis ("rJoystickX") < -.85f) && rStickNeutral) {
				newPosition = transform.position -= Vector3.right * 1.7f;
				transform.position = Vector2.MoveTowards (transform.position, newPosition, moveSpeed);
				rStickNeutral = false;

				SFX.clip = move;
				SFX.Play ();
			
				this.GetComponent<SpriteRenderer> ().flipX = true;
			}
			if ((Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow) || Input.GetAxis ("rJoystickX") > .85f) && rStickNeutral)  {
				newPosition = transform.position += Vector3.right * 1.7f;
				transform.position = Vector2.MoveTowards (transform.position, newPosition, moveSpeed);
				rStickNeutral = false;

				SFX.clip = move;
				SFX.Play ();

				this.GetComponent<SpriteRenderer> ().flipX = false;
			}
			if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetAxis ("rJoystickY") > .85f) && rStickNeutral) {
				newPosition = transform.position += Vector3.up * 1.7f;
				transform.position = Vector2.MoveTowards (transform.position, newPosition, moveSpeed);
				rStickNeutral = false;

				SFX.clip = move;
				SFX.Play ();

				this.GetComponent<SpriteRenderer> ().sprite = back;
			}
			if ((Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow) || Input.GetAxis ("rJoystickY") < -.85f) && rStickNeutral) {
				newPosition = transform.position -= Vector3.up * 1.7f;
				transform.position = Vector2.MoveTowards (transform.position, newPosition, moveSpeed);
				rStickNeutral = false;

				SFX.clip = move;
				SFX.Play ();

				this.GetComponent<SpriteRenderer> ().sprite = front;

			}

//			if (transform.position == newPosition) {
//				rStickNeutral = true;
//			}
	
			transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
			chatterCheck ();
		}
	}

	void chatterCheck ()	{
		if (Vector2.Distance (gameObject.transform.position, babot.transform.position) <= distanceCheck) {
			nearBabot = true;
		} else 
			nearBabot = false;
		
		if (Vector2.Distance (gameObject.transform.position, npc1.transform.position) <= distanceCheck) {
			nearNpc1 = true;
		} else
			nearNpc1 = false;
		
		if (Vector2.Distance (gameObject.transform.position, npc2.transform.position) <= distanceCheck) {
			nearNpc2 = true;
		} else
			nearNpc2 = false;
		
		if (Vector2.Distance (gameObject.transform.position, npc3.transform.position) <= distanceCheck) {
			nearNpc3 = true;
		} else
			nearNpc3 = false;
	}
}
