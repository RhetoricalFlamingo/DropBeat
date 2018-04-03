using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatCounter : MonoBehaviour {

	public float currentTime;
	public float beatTime;
	public float bufferPeriod;

	public bool onBeat;

	public SpriteRenderer beatSpriteRenderer;

	public GameObject ABTran;
	public bool inBattle;

	public GameObject stateMachineObject;
	public GameObject flawlessText;
	public bool flawless = true;
	public bool turnUpdate = false;

	public bool ISBACKGROUND = false;
	int currentSprite = 1;
	public Sprite[] backgrounds = new Sprite[4];

	void Start () {
		beatSpriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		if (!ISBACKGROUND) {
			if (Input.anyKeyDown && onBeat == false) {
				flawless = false;
			}

			turnUpdate = stateMachineObject.GetComponent<stateMachine> ().turnUpdate;

			if (turnUpdate == true) {
				flawless = true;
				turnUpdate = false;
			}

			if (flawless) {
				flawlessText.GetComponent<TextMesh> ().text = "Flawless!";
			}
			if (!flawless) {
				flawlessText.GetComponent<TextMesh> ().text = "";
			}
		}
	}


	void FixedUpdate () {
		inBattle = ABTran.GetComponent<ABTransition> ().inBattle;

		if (inBattle) {

			currentTime += Time.deltaTime;

			if (currentTime >= (beatTime - bufferPeriod) && currentTime <= (beatTime + bufferPeriod)) {
				onBeat = true;
			} else
				onBeat = false;

			if (currentTime > (beatTime + bufferPeriod)) {
				currentTime = 0;
			}

			if (!ISBACKGROUND) {
				if (onBeat) {
					beatSpriteRenderer.enabled = true;
					transform.localScale -= new Vector3 (.00375f, .00375f, 0);
				} else {
					beatSpriteRenderer.enabled = false;
					transform.localScale = new Vector3 (0.06598309f, 0.06657582f, 1f);
				}
			} else if (ISBACKGROUND) {
				if (currentTime == 0) {
					currentSprite++;
				}
				if (currentSprite > 3) {
					currentSprite = 0;
				}

				this.GetComponent<SpriteRenderer> ().sprite = backgrounds [currentSprite];
			}
		}	
	}
}
