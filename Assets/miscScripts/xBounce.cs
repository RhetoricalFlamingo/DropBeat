using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xBounce : MonoBehaviour {

	public float bounceDuration = 1.0f;
	float bounceTimer = 0.0f;

	public float bounceSpeed;

	bool goingUp = false;
	bool flippedThisFrame = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {

		if (!goingUp) {
			gameObject.transform.position -= new Vector3 (0, bounceSpeed * Time.deltaTime, 0);
			//Debug.Log ("goingdown");
		}
		if (goingUp) {
			gameObject.transform.position += new Vector3 (0, bounceSpeed * Time.deltaTime, 0);
			//Debug.Log ("goingup");
		}

		if (bounceTimer >= bounceDuration) {
			if (!goingUp && !flippedThisFrame) {
				goingUp = true;
				//Debug.Log ("up");
				flippedThisFrame = true;
			}

			if (goingUp && !flippedThisFrame) {
				goingUp = false;
				//Debug.Log ("down");
				flippedThisFrame = true;
			}

			bounceTimer = 0.0f;
		}

		bounceTimer += Time.deltaTime;
		flippedThisFrame = false;
	}
}
