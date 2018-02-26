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
	public bool flawless = true;
	public bool turnUpdate = false;

	void Start () {
		beatSpriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		if (Input.anyKeyDown && onBeat == false) {
			flawless = false;
		}

		turnUpdate = stateMachineObject.GetComponent<stateMachine> ().turnUpdate;

		if (turnUpdate == true) {
			flawless = true;
			turnUpdate = false;
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

			if (onBeat) {
				beatSpriteRenderer.enabled = true;
			} else
				beatSpriteRenderer.enabled = false;
		}	
	}
}
