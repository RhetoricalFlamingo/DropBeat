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

	public int currentTurn = 0;
	bool turnFinished = false;
	public string currentAction = "";
	public string currentMenu = "";
	string previousMenu = "";

	int decisionAI = 0;

	int target = 0;

	public GameObject faceButtonUI;
	public SpriteRenderer faceButtonRend;
	public Sprite faceInit;
	public Sprite faceTarget;
	public Sprite faceDance;
	public Sprite faceItem;

	public class CharacterData
	{
		public int maxHp;
		public int currentHp;
		public bool isAlive;

		public string dance1;
		public string dance2;
		public string dance3;

		public string item1;
		public string item2;
		public string item3;

		public int fightDam;

	}

	CharacterData[] charDatas = new CharacterData[6];

	void Start () {
		transform.position = oneFriendlyPosition;
		currentTurn = 1;

		faceButtonRend = faceButtonUI.GetComponent<SpriteRenderer> ();

		//Finish character class declaration and initialisation
	}

	void Update () {
		if (currentTurn == 1) {
			transform.position = oneFriendlyPosition;
		}
		if (currentTurn == 2) {
			transform.position = twoFriendlyPosition;
			Debug.Log ("2");
		}
		if (currentTurn == 3) {
			transform.position = threeFriendlyPosition;
		}
		if (currentTurn == 4) {
			transform.position = oneEnemyPosition;
		}
		if (currentTurn == 5) {
			transform.position = twoEnemyPosition;
		}
		if (currentTurn == 6) {
			transform.position = threeEnemyPosition;
		}
///////////////////////////////////////////////////////////////////////////////////
//********HUMAN PLAYER INPUT********///////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////	
		if (currentTurn < 4) {		//add "&& oneFriendlyDat.isAlive, and make this a FOR statment

///////////////////////////////////////////////////////////////////////////////////
//**************TOP MENU/////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////
			if (currentMenu == "") {		//Fight goes directly to targeting menu
				faceButtonRend.sprite = faceInit;

				if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
					currentAction = "fight";
					currentMenu = "target";
				} else if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
					currentMenu = "dance";
				} else if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
					currentMenu = "item";
				} else if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
					currentMenu = "run";
				}
			}

			if (currentMenu == "dance") {
				faceButtonRend.sprite = faceDance;
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

			if (currentMenu == "item") {
				faceButtonRend.sprite = faceItem;
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
//***********TARGETING MENU///////////////////////////////////////////////////////////////////////////
/// //////////////////////////////////////////////////////////////////////////////////////
			if (currentMenu == "target") {
				faceButtonRend.sprite = faceTarget;

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

			if (currentMenu == "run") {
				Debug.Log ("There's no escaping!");
				currentMenu = "";
			}
		}

///////////////////////////////////////////////////////////////////////////////////
//********AI AutoINPUT********///////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////	
		if (currentTurn >= 4) {
			for (int i = 4; i < 7; i++) {

				decisionAI = (int)Random.Range(0, 3);

//**************Fight
				if (decisionAI == 0) {
					charDatas[(int)Random.Range (0, 2)].currentHp -= charDatas [i].fightDam;
				}
				if (decisionAI == 1) {
					
				}



				currentTurn++;
			}
		}
	
//////////////////////////////////////////////////////////////////////////////////////////
		//POTENTIAL ACTIONS READER
		if (turnFinished) {

///////////////////////////////////////////////////////////////FIGHT
			if (currentAction == "fight") {
				if (target == 1) {
					//deal fight damage to target 1
				}
				if (target == 2) {
					//deal fight damage to target 2
				}
				if (target == 3) {
					//deal fight damage to target 3
				}
			}
///////////////////////////////////////////////////////////////DANCE
			if (currentTurn == 1) {			//PC1
				if (currentAction == "dance1") {
					if (target == 1) {
						//PC 1's dance 1 on target 1
					}
					if (target == 2) {
						//PC 1's dance 1 on target 2
					}
					if (target == 3) {
						//PC 1's dance 1 on target 3
					}
				}
				if (currentAction == "dance2") {
					if (target == 1) {
						//PC 1's dance 2 on target 1
					}
					if (target == 2) {
						//PC 1's dance 2 on target 2
					}
					if (target == 3) {
						//PC 1's dance 2 on target 3
					}
				}
				if (currentAction == "dance3") {
					if (target == 1) {
						//PC 1's dance 3 on target 1
					}
					if (target == 2) {
						//PC 1's dance 3 on target 2
					}
					if (target == 3) {
						//PC 1's dance 3 on target 3
					}
				}
			}
///////////////////////////////////////////////////////////////
			if (currentTurn == 2) {			//PC2
				if (currentAction == "dance1") {
					if (target == 1) {
						//PC 2's dance 1 on target 1
					}
					if (target == 2) {
						//PC 2's dance 1 on target 2
					}
					if (target == 3) {
						//PC 2's dance 1 on target 3
					}
				}
				if (currentAction == "dance2") {
					if (target == 1) {
						//PC 2's dance 2 on target 1
					}
					if (target == 2) {
						//PC 2's dance 2 on target 2
					}
					if (target == 3) {
						//PC 2's dance 2 on target 3
					}
				}
				if (currentAction == "dance3") {
					if (target == 1) {
						//PC 2's dance 3 on target 1
					}
					if (target == 2) {
						//PC 2's dance 3 on target 2
					}
					if (target == 3) {
						//PC 2's dance 3 on target 3
					}
				}
			}
///////////////////////////////////////////////////////////////
			if (currentTurn == 3) {			//PC23
				if (currentAction == "dance1") {
					if (target == 1) {
						//PC 3's dance 1 on target 1
					}
					if (target == 2) {
						//PC 3's dance 1 on target 2
					}
					if (target == 3) {
						//PC 3's dance 1 on target 3
					}
				}
				if (currentAction == "dance2") {
					if (target == 1) {
						//PC 3's dance 2 on target 1
					}
					if (target == 2) {
						//PC 3's dance 2 on target 2
					}
					if (target == 3) {
						//PC 3's dance 2 on target 3
					}
				}
				if (currentAction == "dance3") {
					if (target == 1) {
						//PC 3's dance 3 on target 1
					}
					if (target == 2) {
						//PC 3's dance 3 on target 2
					}
					if (target == 3) {
						//PC 3's dance 3 on target 3
					}
				}
			}

///////////////////////////////////////////////////////////////ITEM
			if (currentTurn == 1) {			//PC1
				if (currentAction == "item1") {
					if (target == 1) {
						//PC 1's item 1 on target 1
					}
					if (target == 2) {
						//PC 1's item 1 on target 2
					}
					if (target == 3) {
						//PC 1's item 1 on target 3
					}
				}
				if (currentAction == "item2") {
					if (target == 1) {
						//PC 1's item 2 on target 1
					}
					if (target == 2) {
						//PC 1's item 2 on target 2
					}
					if (target == 3) {
						//PC 1's item 2 on target 3
					}
				}
				if (currentAction == "item3") {
					if (target == 1) {
						//PC 1's item 3 on target 1
					}
					if (target == 2) {
						//PC 1's item 3 on target 2
					}
					if (target == 3) {
						//PC 1's item 3 on target 3
					}
				}
			}
///////////////////////////////////////////////////////////////
			if (currentTurn == 2) {			//PC2
				if (currentAction == "item1") {
					if (target == 1) {
						//PC 2's item 1 on target 1
					}
					if (target == 2) {
						//PC 2's item 1 on target 2
					}
					if (target == 3) {
						//PC 2's item 1 on target 3
					}
				}
				if (currentAction == "item2") {
					if (target == 1) {
						//PC 2's item 2 on target 1
					}
					if (target == 2) {
						//PC 2's item 2 on target 2
					}
					if (target == 3) {
						//PC 2's item 2 on target 3
					}
				}
				if (currentAction == "item3") {
					if (target == 1) {
						//PC 2's item 3 on target 1
					}
					if (target == 2) {
						//PC 2's item 3 on target 2
					}
					if (target == 3) {
						//PC 2's item 3 on target 3
					}
				}
			}
///////////////////////////////////////////////////////////////
			if (currentTurn == 3) {			//PC23
				if (currentAction == "item1") {
					if (target == 1) {
						//PC 3's item 1 on target 1
					}
					if (target == 2) {
						//PC 3's item 1 on target 2
					}
					if (target == 3) {
						//PC 3's item 1 on target 3
					}
				}
				if (currentAction == "item2") {
					if (target == 1) {
						//PC 3's item 2 on target 1
					}
					if (target == 2) {
						//PC 3's item 2 on target 2
					}
					if (target == 3) {
						//PC 3's item 2 on target 3
					}
				}
				if (currentAction == "item3") {
					if (target == 1) {
						//PC 3's item 3 on target 1
					}
					if (target == 2) {
						//PC 3's item 3 on target 2
					}
					if (target == 3) {
						//PC 3's item 3 on target 3
					}
				}
			}
			

			currentTurn++;
			turnFinished = false;
			currentMenu = "";
			currentAction = "";

			if (currentTurn > 6) {
				currentTurn = 1;
			}
		}
	}
}
