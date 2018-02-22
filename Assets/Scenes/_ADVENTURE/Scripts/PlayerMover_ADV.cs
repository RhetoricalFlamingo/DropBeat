using System.Collections;
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

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		moveSpeed = playerSpeed * Time.deltaTime;

		if (Input.GetAxis ("rJoystickX") < .15f && Input.GetAxis ("rJoystickX") > -.15f && Input.GetAxis ("rJoystickY") < .15f && Input.GetAxis ("rJoystickY") > -.15f) {
			rStickNeutral = true;
		}

		inBattle = ABTran.GetComponent<ABTransition> ().inBattle;

		if (!inBattle) {

			if ((Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) || Input.GetAxis ("rJoystickX") < -.85f) && rStickNeutral) {
				newPosition = transform.position -= Vector3.right * 1.5f;
				transform.position = Vector2.MoveTowards (transform.position, newPosition, moveSpeed);
				rStickNeutral = false;
			}
			if ((Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow) || Input.GetAxis ("rJoystickX") > .85f) && rStickNeutral)  {
				newPosition = transform.position += Vector3.right * 1.5f;
				transform.position = Vector2.MoveTowards (transform.position, newPosition, moveSpeed);
				rStickNeutral = false;
			}
			if ((Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) || Input.GetAxis ("rJoystickY") > .85f) && rStickNeutral) {
				newPosition = transform.position += Vector3.up * 1.5f;
				transform.position = Vector2.MoveTowards (transform.position, newPosition, moveSpeed);
				rStickNeutral = false;
			}
			if ((Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow) || Input.GetAxis ("rJoystickY") < -.85f) && rStickNeutral) {
				newPosition = transform.position -= Vector3.up * 1.5f;
				transform.position = Vector2.MoveTowards (transform.position, newPosition, moveSpeed);
				rStickNeutral = false;
			}

//			if (transform.position == newPosition) {
//				rStickNeutral = true;
//			}
	
			transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
		}
	}
}
