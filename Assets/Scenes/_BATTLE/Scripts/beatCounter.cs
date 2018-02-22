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

	// Use this for initialization
	void Start () {
		beatSpriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
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
