using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateMachine : MonoBehaviour {

//Different Reticule Positions
	public Vector3 oneFriendlyPosition = new Vector3 (0, 0, 0);
	public Vector3 twoFriendlyPosition = new Vector3 (0, 0, 0);
	public Vector3 threeFriendlyPosition = new Vector3 (0, 0, 0);
	public Vector3 oneEnemyPosition = new Vector3 (0, 0, 0);
	public Vector3 twoEnemyPosition = new Vector3 (0, 0, 0);
	public Vector3 threeEnemyPosition = new Vector3 (0, 0, 0);

	int currentTurn = 0;
	bool turnFinished = false;
	string currentAction = "";

	public GameObject faceButtonUI;
	public SpriteRenderer faceButtonRend;
	public Sprite faceInit;
	public Sprite faceTarget;

	public class oneFriendlyDat
	{
		int maxHp;
		int currentHp;
		bool isAlive;

		int fightDam;
	}

	// Use this for initialization
	void Start () {
		transform.position = oneFriendlyPosition;
		currentTurn = 1;

		faceButtonRend = faceButtonUI.GetComponent<SpriteRenderer> ();

		//Finish character class declaration and initialisation
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTurn == 1) {		//add "&& oneFriendlyDat.isAlive
			transform.position = oneFriendlyPosition;

			if (currentAction == "") {
				//faceButtonRend = faceInit;

				if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
					currentAction = "fight";
				}	else if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
					currentAction = "dance";
				}	else if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
					currentAction = "item";
				}	else if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
					currentAction = "run";
				}
			}

			if (currentAction == "fight") {
				if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
					//oneEnemyDat.currentHP -= oneFriendlyDat.fightDam;
					turnFinished = true;
				} else if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
					//twoEnemyDat.currentHP -= oneFriendlyDat.fightDam;
					turnFinished = true;
				} else if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
					//threeEnemyDat.currentHP -= oneFriendlyDat.fightDam;
					turnFinished = true;
				} else if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
					currentAction = "";
				}
			}

			if (currentAction == "dance") {
				if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
					//oneEnemyDat.currentHP -= oneFriendlyDat.fightDam;
					turnFinished = true;
				} else if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
					//twoEnemyDat.currentHP -= oneFriendlyDat.fightDam;
					turnFinished = true;
				} else if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
					//threeEnemyDat.currentHP -= oneFriendlyDat.fightDam;
					turnFinished = true;
				} else if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
					currentAction = "";
				}
			}

			if (currentAction == "item") {
				if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
					//oneEnemyDat.currentHP -= oneFriendlyDat.fightDam;
					turnFinished = true;
				} else if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
					//twoEnemyDat.currentHP -= oneFriendlyDat.fightDam;
					turnFinished = true;
				} else if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
					//threeEnemyDat.currentHP -= oneFriendlyDat.fightDam;
					turnFinished = true;
				} else if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
					currentAction = "";
				}
			}

			if (currentAction == "run") {
				Debug.Log ("There's no escaping!");
				currentAction = "";
			}
		}

		if (turnFinished) {
			turnFinished = false;
			currentTurn++;
		}

		if (currentTurn >= 7) {
			currentTurn = 1;
		}
	}
}
