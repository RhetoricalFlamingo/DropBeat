using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover_ADV : MonoBehaviour {

	float playerSpeed = 0;
	public float playerSpeedSet = 0;

	Vector3 previousPosition = new Vector2 (0, 0);
	Vector3 newPosition = new Vector2 (0, 0);
	private float startTime;
	private float journeyDistance;

	public float moveSpeed = 0;

	// Use this for initialization
	void Start () {
		journeyDistance = Vector2.Distance (previousPosition, newPosition);
	}
	
	// Update is called once per frame
	void Update () {
		playerSpeed = playerSpeedSet;
		playerSpeed *= Time.deltaTime;


		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) || Input.GetAxis ("rJoystickX") < -.85f) {
			//transform.position += -Vector3.right * playerSpeed;
			startTime = Time.time;
			previousPosition = transform.position;
			newPosition = transform.position -= Vector3.right * 1.5f;
			float distCovered = (Time.time - startTime) * moveSpeed;
			float fracJourney = distCovered / journeyDistance;
			transform.position = Vector3.Lerp (previousPosition, newPosition, fracJourney);
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow) || Input.GetAxis ("rJoystickX") > .85f) {
			//transform.position += Vector3.right * playerSpeed;
			startTime = Time.time;
			previousPosition = transform.position;
			newPosition = transform.position += Vector3.right * 1.5f;
			float distCovered = (Time.time - startTime) * moveSpeed;
			float fracJourney = distCovered / journeyDistance;
			transform.position = Vector3.Lerp (previousPosition, newPosition, fracJourney);
		}
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) || Input.GetAxis ("rJoystickY") > .85f) {
			//transform.position += Vector3.up * playerSpeed;
			startTime = Time.time;
			previousPosition = transform.position;
			newPosition = transform.position += Vector3.up * 1.5f;
			float distCovered = (Time.time - startTime) * moveSpeed;
			float fracJourney = distCovered / journeyDistance;
			transform.position = Vector3.Lerp (previousPosition, newPosition, fracJourney);
		}
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow) || Input.GetAxis ("rJoystickY") < -.85f) {
			//transform.position += -Vector3.up * playerSpeed;
			startTime = Time.time;
			previousPosition = transform.position;
			newPosition = transform.position -= Vector3.up * 1.5f;
			float distCovered = (Time.time - startTime) * moveSpeed;
			float fracJourney = distCovered / journeyDistance;
			transform.position = Vector3.Lerp (previousPosition, newPosition, fracJourney);
		}
	
		transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
	}
}
