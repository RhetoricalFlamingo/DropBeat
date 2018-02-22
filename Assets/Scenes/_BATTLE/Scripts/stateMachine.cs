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

	[System.Serializable]
	public class CharacterData
	{
		public int maxHp;
		public int currentHp;
		public bool isAlive;

		public int fightDam;
		public bool charged;
	}

	bool stirThePot = false;

	CharacterData[] charDatas = new CharacterData[6];

	public bool inBattle = false;
	public GameObject ABTran;

	void Start () {
		transform.position = oneFriendlyPosition;
		currentTurn = 1;

		faceButtonRend = faceButtonUI.GetComponent<SpriteRenderer> ();

		statInit ();
	}

	void Update () {
		inBattle = ABTran.GetComponent<ABTransition> ().inBattle;

		if (inBattle) {
			
			reticulePosition ();
///////////////////////////////////////////////////////////////////////////////////
//********HUMAN PLAYER INPUT********///////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////	
			if (currentTurn < 4) {		//add "&& oneFriendlyDat.isAlive, and make this a FOR statment

				if (charDatas [currentTurn - 1].isAlive) {
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
						

					if (currentMenu == "") {		//Fight goes directly to targeting menu
						faceButtonRend.sprite = faceInit;

						if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
							currentAction = "fight";
							currentMenu = "target";
						} else if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
							currentMenu = "dance";
						} else if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
							currentMenu = "run";
						}
					}

					if (currentMenu == "run") {
						Debug.Log ("There's no escaping!");
						currentMenu = "";
					}
				}

				if (!charDatas [currentTurn - 1].isAlive) {
					currentMenu = "";
					currentAction = "";
					turnFinished = true;
				}
			}
				
			combatAI ();
	
//////////////////////////////////////////////////////////////////////////////////////////
			//POTENTIAL ACTIONS READER
			if (turnFinished) {

///////////////////////////////////////////////////////////////FIGHT
				if (currentAction == "fight") {
					charDatas [target + 2].currentHp -= charDatas [currentTurn].fightDam;
					Debug.Log ("Fight: " + charDatas [target + 2].currentHp);
				}
///////////////////////////////////////////////////////////////DANCE
				if (currentTurn == 1) {			//PC1
					if (currentAction == "dance1") {	// X
						for (int i = 3; i < 6; i++) {		//AOE
							charDatas [i].currentHp -= 10;
							Debug.Log ("AOE Dance: " + charDatas [i].currentHp);
						}
					}
					if (currentAction == "dance2") {	// []
						charDatas[target + 2].currentHp -= 30;		//Recoil Hit
						charDatas [currentTurn - 1].currentHp -= 10;
						Debug.Log ("RECOIL Dance: " + charDatas [target + 2].currentHp + " - " + charDatas [currentTurn - 1].currentHp);

					}
					if (currentAction == "dance3") {	// /\
						Debug.Log ("Action Unwritten");		//TBD
					}
				}
///////////////////////////////////////////////////////////////
				if (currentTurn == 2) {			//PC2
					if (currentAction == "dance1") {
						for (int i = 0; i < 3; i++) {
							charDatas [i].currentHp += 8;
							Debug.Log ("TEAMHEAL Dance: " + charDatas [i].currentHp);
						}
					}
					if (currentAction == "dance2") {
						charDatas [target + 2].currentHp -= 8;
						charDatas [currentTurn - 1].currentHp += 5;
						Debug.Log ("VAMP Dance: " + charDatas [target + 2].currentHp + " - " + charDatas [currentTurn - 1].currentHp);
					}
					if (currentAction == "dance3") {
						charDatas [target + 2].currentHp -= 15;
						Debug.Log ("Placeholder HIT");
					}
				}
///////////////////////////////////////////////////////////////
				if (currentTurn == 3) {			//PC3
					if (currentAction == "dance1") {
						charDatas [currentTurn - 1].currentHp += 12;
						Debug.Log ("SELFHEAL Dance: " + charDatas [currentTurn - 1].currentHp);
					}
					if (currentAction == "dance2") {
						Debug.Log ("Action Unwritten");
					}
					if (currentAction == "dance3") {
						stirThePot = true;
						Debug.Log ("StirThePot");
					}
				}

				//*****ITEMS HAVE BEEN REMOVED - TAKE 'EM OUT OF THE MENU HIERARCHY

				currentTurn++;
				turnFinished = false;
				currentMenu = "";
				currentAction = "";
			}

			if (currentTurn > 6) {
				currentTurn = 1;
			}

			healthMonitor ();
		}
	}

	public void reticulePosition ()	{
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
	}

	public void statInit ()	{
		//**************STATS INIT***************************************************
		//-1
		charDatas [0] = new CharacterData ();
		charDatas [0].maxHp = 100;
		charDatas [0].currentHp = charDatas [0].maxHp;
		charDatas [0].isAlive = true;
		//charDatas [0].dance1 = Headspin (AOE)
		//charDatas [0].dance2 = Beatdown (Heavy, single target, recoil)
		//charDatas [0].dance3 = Upstage  (Next AI to go loses their turn)
		charDatas [0].fightDam = 18;
		charDatas [0].charged = false;
		//-2
		charDatas [1] = new CharacterData ();
		charDatas [1].maxHp = 85;
		charDatas [1].currentHp = charDatas [1].maxHp;
		charDatas [1].isAlive = true;
		//charDatas [0].dance1 = All Together Now (group heal)
		//charDatas [0].dance2 = Fire Bird (damage and life-drain)
		//charDatas [0].dance3 = High Kick (heavy single target damage, has cooldown)
		charDatas [1].fightDam = 10;
		charDatas [1].charged = false;
		//-3
		charDatas [2] = new CharacterData ();
		charDatas [2].maxHp = 120;
		charDatas [2].currentHp = charDatas [2].maxHp;
		charDatas [2].isAlive = true;
		//charDatas [0].dance1 = Lawnmower (self heal)
		//charDatas [0].dance2 = Windmill (Reflect damage this turn)
		//charDatas [0].dance3 = Stir The Pot (taunt)
		charDatas [2].fightDam = 12;
		charDatas [2].charged = false;
		//-BADDIE_1
		charDatas [3] = new CharacterData ();
		charDatas [3].maxHp = 120;
		charDatas [3].currentHp = charDatas [3].maxHp;
		charDatas [3].isAlive = true;
		//charDatas [0].dance1 = Blast (AOE)
		//charDatas [0].dance2 = Legion (Heal)
		//charDatas [0].dance3 = Charge
		charDatas [3].fightDam = 12;
		charDatas [3].charged = false;
		//-BADDIE_2
		charDatas [4] = new CharacterData ();
		charDatas [4].maxHp = 120;
		charDatas [4].currentHp = charDatas [4].maxHp;
		charDatas [4].isAlive = true;
		//charDatas [0].dance1 = Blast (AOE)
		//charDatas [0].dance2 = Legion (Heal)
		//charDatas [0].dance3 = Charge
		charDatas [4].fightDam = 12;
		charDatas [4].charged = false;
		//-BADDIE_3
		charDatas [5] = new CharacterData ();
		charDatas [5].maxHp = 120;
		charDatas [5].currentHp = charDatas [5].maxHp;
		charDatas [5].isAlive = true;
		//charDatas [0].dance1 = Blast (AOE)
		//charDatas [0].dance2 = Legion (Heal)
		//charDatas [0].dance3 = Charge
		charDatas [5].fightDam = 12;
		charDatas [5].charged = false;
	}

	public void healthMonitor ()	{
		for (int i = 0; i < 6; i++) {
			if (charDatas [i].currentHp > charDatas [i].maxHp) {
				charDatas [i].currentHp = charDatas [i].maxHp;
			}

			if (charDatas [i].currentHp <= 0) {
				charDatas [i].isAlive = false;
			}
		}
	}

	public void combatAI ()	{
		if (currentTurn >= 4) {
			for (int i = 3; i < 6; i++) {

				decisionAI = (int)Random.Range (0, 99);

				if (charDatas [i].charged) {	//If the last turn was spent charging up, this turn is a guaranteed FIGHT action
					decisionAI = 0;
				}
				if (decisionAI > 40 && decisionAI <= 60 && charDatas [i].currentHp <= (int)(charDatas [i].maxHp * .3f)) {	 //If BLAST would kill the AI, it uses FIGHT instead
					decisionAI = 0;
				}
				if (!charDatas [i].isAlive) {
					decisionAI = 100;
				}

				//**************Fight
				if (decisionAI <= 40) {
					if (charDatas [i].charged) {
						if (stirThePot) {
							charDatas [2].currentHp -= (int)(charDatas [i].fightDam * 2.5);
							charDatas [i].charged = false;
							stirThePot = false;
						} else {
							charDatas [(int)Random.Range (0, 2)].currentHp -= (int)(charDatas [i].fightDam * 2.5);
							charDatas [i].charged = false;
						}
					} else if (!charDatas [i].charged) {
						if (stirThePot) {
							charDatas [2].currentHp -= charDatas [i].fightDam;
							stirThePot = false;
						} else {
							charDatas [(int)Random.Range (0, 2)].currentHp -= charDatas [i].fightDam;
						}
					}
					Debug.Log ("Enemy " + (i-2) + " Used FIGHT");
				}
				//**************Blast
				else if (decisionAI > 40 && decisionAI <= 60) {
					charDatas [0].currentHp -= (int)(charDatas [i].fightDam * .4f);
					charDatas [1].currentHp -= (int)(charDatas [i].fightDam * .4f);
					charDatas [2].currentHp -= (int)(charDatas [i].fightDam * .4f);
					charDatas [i].currentHp -= (int)(charDatas [i].maxHp * .3f);

					Debug.Log ("Enemy " + (i-2) + " Used BLAST");
				}
				//**************Legion
				else if (decisionAI > 60 && decisionAI <= 70) {
					charDatas [(int)Random.Range (3, 5)].currentHp += 20;

					Debug.Log ("Enemy " + (i-2) + " Used LEGION");
				}
				//**************Charge
				else if (decisionAI > 70) {
					charDatas [i].charged = true;

					Debug.Log ("Enemy " + (i-2) + " Used CHARGE");
				} 
				//**************DEAD
				else if (decisionAI == 100) {
					//isDead
				}



				currentTurn++;
			}
		}
	}
}