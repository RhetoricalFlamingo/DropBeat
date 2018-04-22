using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour {

	public GameObject backer;
	public GameObject cam;
	public Sprite main;
	public Sprite controls;

	public Vector3 mainVectorBacker;
	public Vector3 controlVectorBacker;

	public Vector3 mainVectorCam;
	public Vector3 controlVectorCam;
	public Vector3 sideVectorCam;

	bool onMain = false;
	bool onControl = false;
	bool onSide = false;
	bool moveSwitch = false;
	float camSpeed;

	// Use this for initialization
	void Start () {
		onMain = true;
	}
	
	// Update is called once per frame
	void Update () {
		moveSwitch = true;

		if (onMain) {
			backer.GetComponent<SpriteRenderer> ().sprite = main;
			backer.transform.position = mainVectorBacker;
			cam.transform.position = mainVectorCam;

			if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
				backer.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0);
				SceneManager.LoadScene ("adventure");
			}

			if (Input.GetAxis ("rJoystickY") < -.85f) {
				onMain = false;
				onControl = true;
			}
		}
		if (onControl) {
			backer.GetComponent<SpriteRenderer> ().sprite = controls;
			backer.transform.position = controlVectorBacker;
			if (cam.transform.position.x > controlVectorCam.x) {
				camSpeed = Vector3.Distance (cam.transform.position, controlVectorCam) * 1.5f + 16;
				cam.transform.position -= Vector3.right * camSpeed * Time.deltaTime;
			}

			if (Input.GetAxis ("rJoystickY") > .85f) {
				onMain = true;
				onControl = false;
			}
			if (Input.GetKeyDown (KeyCode.JoystickButton1) && moveSwitch) {
				onControl = false;
				onSide = true;
				moveSwitch = false;
			}
		}
		if (onSide) {
			backer.GetComponent<SpriteRenderer> ().sprite = controls;
			backer.transform.position = controlVectorBacker;
			if (cam.transform.position.x < sideVectorCam.x) {
				camSpeed = Vector3.Distance (cam.transform.position, sideVectorCam) * 1.5f + 16;
				cam.transform.position += Vector3.right * camSpeed * Time.deltaTime;
			}

			if (Input.GetKeyDown (KeyCode.JoystickButton1) && moveSwitch) {
				onControl = true;
				onSide = false;
				moveSwitch = false;
			}
		}
	}
}
