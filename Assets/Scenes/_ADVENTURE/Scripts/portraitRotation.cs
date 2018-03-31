using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portraitRotation : MonoBehaviour {

	public float rotateDuration = 1.0f;
	float rotateTimer = 0.0f;

	public float rotateSpeedY;
	public float rotateSpeedZ;

	bool goingRight = false;
	bool flippedThisFrame = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (goingRight) {
			gameObject.transform.Rotate (0, rotateSpeedY * Time.deltaTime, rotateSpeedZ * Time.deltaTime);
		}
		if (!goingRight) {
			gameObject.transform.Rotate (0, -rotateSpeedY * Time.deltaTime, -rotateSpeedZ * Time.deltaTime);
		}

		if (rotateTimer >= rotateDuration) {
			if (goingRight && !flippedThisFrame) {
				goingRight = false;
				flippedThisFrame = true;
			} 
			else if (!goingRight && !flippedThisFrame) {
				goingRight = true;
				flippedThisFrame = true;
			}

			rotateTimer = 0.0f;
		}

		rotateTimer += Time.deltaTime;
		flippedThisFrame = false;
	}
}
