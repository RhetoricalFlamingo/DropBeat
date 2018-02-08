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
		public bool charged;
	}

	CharacterData[] charDatas = new CharacterData[6];

	void Start () {
		transform.position = oneFriendlyPosition;
		currentTurn = 1;

		faceButtonRend = faceButtonUI.GetComponent<SpriteRenderer> ();

//**************STATS INIT***************************************************
//-1
		charDatas [0].maxHp = 100;
		charDatas [0].currentHp = charDatas [0].maxHp;
		charDatas [0].isAlive = true;
		//charDatas [0].dance1 = Headspin (AOE)
		//charDatas [0].dance2 = Beatdown (Heavy, single target, recoil)
		//charDatas [0].dance3 = Upstage  (Next AI to go loses their turn)
		//charDatas [0].item1 = Pick-Me-Up (heal)
		//charDatas [0].item2 = Metal Amp (enemies and allies both deal 2X Dam this turn)
		//charDatas [0].item3 = _empty_
		charDatas [0].fightDam = 18;
		charDatas [0].charged = false;
//-2
		charDatas [1].maxHp = 85;
		charDatas [1].currentHp = charDatas [0].maxHp;
		charDatas [1].isAlive = true;
		//charDatas [0].dance1 = All Together Now (group heal)
		//charDatas [0].dance2 = Fire Bird (damage and life-drain)
		//charDatas [0].dance3 = High Kick (heavy single target damage, has cooldown)
		//charDatas [0].item1 = Pick-Me-Up (heal)
		//charDatas [0].item2 = Metal Amp (enemies and allies both deal 2X Dam this turn)
		//charDatas [0].item3 = _empty_
		charDatas [1].fightDam = 10;
		charDatas [1].charged = false;
//-3
		charDatas [2].maxHp = 120;
		charDatas [2].currentHp = charDatas [0].maxHp;
		charDatas [2].isAlive = true;
		//charDatas [0].dance1 = Lawnmower (self heal)
		//charDatas [0].dance2 = Windmill (Reflect damage this turn)
		//charDatas [0].dance3 = Sprinkler (taunt)
		//charDatas [0].item1 = Pick-Me-Up (heal)
		//charDatas [0].item2 = Metal Amp (enemies and allies both deal 2X Dam this turn)
		//charDatas [0].item3 = _empty_
		charDatas [2].fightDam = 12;
		charDatas [2].charged = false;
	}

	void Update () {
		if (currentTurn == 1) {
			transform.position = oneFriendlyPosition;
		}
		if (currentTurn == 2) {
			transform.position = twoFriendlyPosition;
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
					currentMenu = "";
				}
			}

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
				
//////////////////////////////////////////////////////////////////////////////////////
//***********TARGETING MENU///////////////////////////////////////////////////////////////////////////
/// //////////////////////////////////////////////////////////////////////////////////////
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

				decisionAI = (int)Random.Range(0, 99);

				if (charDatas [i].charged) {	//If the last turn was spent charging up, this turn is a guaranteed FIGHT action
					decisionAI = 0;
				}
				if (decisionAI > 40 && decisionAI <= 60 && charDatas [i].currentHp <= (int)(charDatas [i].maxHp * .3f)) {	 //If BLAST would kill the AI, it uses FIGHT instead
					decisionAI = 0;
				}

//**************Fight
				if (decisionAI <= 40) {
					if (charDatas [i].charged) {
						charDatas [(int)Random.Range (0, 2)].currentHp -= (int)(charDatas [i].fightDam * 2.5);
						charDatas [i].charged = false;
					} else if (!charDatas [i].charged) {
						charDatas [(int)Random.Range (0, 2)].currentHp -= charDatas [i].fightDam;
					}
				}
//**************Blast
				else if (decisionAI > 40 && decisionAI <= 60) {
					charDatas [0].currentHp -= (int)(charDatas [i].fightDam * .4f);
					charDatas [1].currentHp -= (int)(charDatas [i].fightDam * .4f);
					charDatas [2].currentHp -= (int)(charDatas [i].fightDam * .4f);
					charDatas [i].currentHp -= (int)(charDatas [i].maxHp * .3f);
				}
//**************Legion
				else if (decisionAI > 60 && decisionAI <= 70) {
					charDatas [(int)Random.Range (3, 5)].currentHp += 20;
				}
//**************Charge
				else if (decisionAI > 70) {
					charDatas [i].charged = true;
				}



				currentTurn++;
			}
		}
	
//////////////////////////////////////////////////////////////////////////////////////////
		//POTENTIAL ACTIONS READER
		if (turnFinished) {

///////////////////////////////////////////////////////////////FIGHT
			if (currentAction == "fight") {
				charDatas [target + 2].currentHp -= charDatas [currentTurn].fightDam;
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
