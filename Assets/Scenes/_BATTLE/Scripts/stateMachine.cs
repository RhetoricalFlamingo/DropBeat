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
	string currentMenu = "";
	string previousMenu = "";

	int target = 0;

	public GameObject faceButtonUI;
	public SpriteRenderer faceButtonRend;
	public Sprite faceInit;
	public Sprite faceTarget;

	public class characterData
	{
		int maxHp;
		int currentHp;
		bool isAlive;

		int fightDam;
	}

	characterData oneFriendData;
	characterData twoFriendData;
	characterData threeFriendData;
	characterData oneEnemyData;
	characterData twoEnemyData;
	characterData threeEnemyData;

	// Use this for initialization
	void Start () {
		transform.position = oneFriendlyPosition;
		currentTurn = 1;

		faceButtonRend = faceButtonUI.GetComponent<SpriteRenderer> ();

		//Finish character class declaration and initialisation
	}
	
	// Update is called once per frame
	void Update () {
		
		if (currentTurn == 1) {		//add "&& oneFriendlyDat.isAlive, and make this a FOR statment
			transform.position = oneFriendlyPosition;

///////////////////////////////////////////////////////////////////////////////////
//////////TOP MENU/////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////
			if (currentMenu == "") {
				//faceButtonRend = faceInit;

				if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
					currentAction = "fight";
					currentMenu = "target";
				}	else if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
					currentMenu = "dance";
				}	else if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
					currentMenu = "item";
				}	else if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
					currentAction = "run";
				}
			}

			if (currentMenu == "dance") {
				previousMenu = "dance";

				if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
					currentAction = "dance1";
					currentMenu = "target";
				} else if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
					currentAction = "dance2";
					currentMenu = "target";
				} else if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
					currentAction = "dance3";
					currentMenu = "target";
				} else if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
					currentMenu = "";	//return to previous menu
				}
			}

			if (currentAction == "item") {
				previousMenu = "item";

				if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
					currentAction = "item1";
					currentMenu = "target";
				} else if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
					currentAction = "item2";
					currentMenu = "target";
				} else if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
					currentAction = "item3";
					currentMenu = "target";
				} else if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
					currentAction = "";
				}
			}
//////////////////////////////////////////////////////////////////////////////////////
/// ///////////TARGETING MENU///////////////////////////////////////////////////////////////////////////
/// //////////////////////////////////////////////////////////////////////////////////////
			if (currentMenu == "target") {
				if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
					target = 1;
					turnFinished = true;
				} else if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
					target = 2;
					turnFinished = true;
				} else if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
					target = 3;
					turnFinished = true;
				} else if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
					currentAction = "";
					currentMenu = previousMenu;
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
