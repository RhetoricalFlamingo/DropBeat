using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stateMachine : MonoBehaviour {

//Different Reticule Positions
	/*public Vector3 oneFriendlyPosition = new Vector3 (0, 0, 0);
	public Vector3 twoFriendlyPosition = new Vector3 (0, 0, 0);
	public Vector3 threeFriendlyPosition = new Vector3 (0, 0, 0);
	public Vector3 oneEnemyPosition = new Vector3 (0, 0, 0);
	public Vector3 twoEnemyPosition = new Vector3 (0, 0, 0);
	public Vector3 threeEnemyPosition = new Vector3 (0, 0, 0);*/

	bool turnChangedThisFrame = false;

	public int currentTurn = 0;
	bool turnFinished = false;
	public bool turnUpdate = false;
	public string currentAction = "";
	public string currentMenu = "";
	string previousMenu = "";

	int decisionAI = 0;

	int target = 0;

	public GameObject faceButtonUI;
	public SpriteRenderer faceButtonRend;
	public Sprite faceInit;
	public Sprite faceTarget;
	public Sprite faceDance1;
	public Sprite faceDance2;
	public Sprite faceDance3;

	public GameObject[] charPortraits = new GameObject[6];

	public GameObject winBacker;
	public GameObject winText;
	public GameObject HPBars;
	public GameObject xPrompt;
	public bool inVictoryScreen = false;
	public GameObject flawlessText;
	public GameObject beatCounter;
	public GameObject gameOver;
	public GameObject loseText;
	public GameObject loseText2;
	public AudioSource BGM;

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
	bool upStage = false;
	int upStageCount = 9;
	bool miracleUsed = false;

	public CharacterData[] charDatas = new CharacterData[6];

	public bool inBattle = false;
	public GameObject ABTran;
	public bool flawless = true;
	public GameObject beatCounterObject;



	void Start () {
		transform.position = charPortraits[0].transform.position + new Vector3 (0,3,-1);
		currentTurn = 1;

		faceButtonRend = faceButtonUI.GetComponent<SpriteRenderer> ();

		statInit ();
	}
	
	void Update () {
		inBattle = ABTran.GetComponent<ABTransition> ().inBattle;

		if (inBattle) {

			turnChangedThisFrame = false;

			flawless = beatCounterObject.GetComponent<beatCounter> ().flawless;
			turnUpdate = false;

			menuing ();
				
			combatAI ();
	
			//POTENTIAL ACTIONS READER
			turnFinishedFunc();

			if (currentTurn > 6) {
				currentTurn = 1;
			}

			reticulePosition ();

			healthMonitor ();
			endGame ();
		}
	}

	public void menuing	()	{
		///////////////////////////////////////////////////////////////////////////////////
		//********HUMAN PLAYER INPUT********///////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////////////	
		if (currentTurn < 4) {

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
					if (currentTurn == 1) {
						faceButtonRend.sprite = faceDance1;
					}
					if (currentTurn == 2) {
						faceButtonRend.sprite = faceDance2;
					}
					if (currentTurn == 3) {
						faceButtonRend.sprite = faceDance3;
					}

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
	}

	public void reticulePosition ()	{
		if (turnChangedThisFrame) {

			transform.position = charPortraits [currentTurn - 1].transform.position + new Vector3 (0,3,-1);

			/*if (currentTurn == 1) {
				transform.position = charPortraits[0].transform.position + new Vector3 (0,3,-1);
			}
			if (currentTurn == 2) {
				transform.position = charPortraits[1].transform.position + new Vector3 (0,3,-1);
			}
			if (currentTurn == 3) {
				transform.position = charPortraits[2].transform.position + new Vector3 (0,3,-1);
			}
			if (currentTurn == 4) {
				transform.position = charPortraits[3].transform.position + new Vector3 (0,3,-1);
			}
			if (currentTurn == 5) {
				transform.position = charPortraits[4].transform.position + new Vector3 (0,3,-1);
			}
			if (currentTurn == 6) {
				transform.position = charPortraits[5].transform.position + new Vector3 (0,3,-1);
			}*/
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
				Destroy (charPortraits [i]);
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
				if (upStageCount == 0) {
					upStage = false;
				}
				if (upStage) {
					decisionAI = 100;
					upStageCount--;
					Debug.Log ("Upstaged!");
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
					Debug.Log ("Enemy " + (i - 2) + " Is DEAD");
				}



				//turnFinished = true;
				currentTurn++;
				turnChangedThisFrame = true;
			}
		}
	}

	public void endGame ()	{
		if (charDatas [0].currentHp <= 0 && charDatas [1].currentHp <= 0 && charDatas [2].currentHp <= 0) {
			xPrompt.SetActive (true);
			HPBars.SetActive (false);
			gameOver.SetActive (true);
			loseText.SetActive (true);
			loseText2.SetActive (true);
			BGM.volume -= .075f;
		}
		if (charDatas [3].currentHp <= 0 && charDatas [4].currentHp <= 0 && charDatas [5].currentHp <= 0) {
			HPBars.SetActive (false);
			xPrompt.SetActive (true);
			winBacker.SetActive (true);
			winText.SetActive (true);
			beatCounter.GetComponent<SpriteRenderer> ().sprite = null;
			flawlessText.SetActive (false);
			faceButtonUI.SetActive (false);
			inVictoryScreen = true;
		}
	}

	public void turnFinishedFunc ()	{
		if (turnFinished) {

			///////////////////////////////////////////////////////////////FIGHT
			if (currentAction == "fight") {
				if (flawless) {
					charDatas [target + 2].currentHp -= (int)(charDatas [currentTurn].fightDam * 1.33f);
					Debug.Log ("FLAWLESS Fight!: " + charDatas [target + 2].currentHp);
				} else {
					charDatas [target + 2].currentHp -= charDatas [currentTurn].fightDam;
					Debug.Log ("Fight: " + charDatas [target + 2].currentHp);
				}
			}
			///////////////////////////////////////////////////////////////DANCE
			if (currentTurn == 1) {			//PC1
				if (currentAction == "dance1") {	// X
					for (int i = 3; i < 6; i++) {		//AOE
						if (flawless) {
							charDatas [i].currentHp -= 15;
							Debug.Log ("FLAWLESS AOE Dance: " + charDatas [i].currentHp);
						} else {
							charDatas [i].currentHp -= 10;
							Debug.Log ("AOE Dance: " + charDatas [i].currentHp);
						}
					}
				}
				if (currentAction == "dance2") {	// []
					if (flawless) {
						charDatas [target + 2].currentHp -= 45;		//Recoil Hit
						charDatas [currentTurn - 1].currentHp -= 10;
						Debug.Log ("FLAWLESS RECOIL Dance: " + charDatas [target + 2].currentHp + " - " + charDatas [currentTurn - 1].currentHp);
					} else {
						charDatas [target + 2].currentHp -= 30;		//Recoil Hit
						charDatas [currentTurn - 1].currentHp -= 10;
						Debug.Log ("RECOIL Dance: " + charDatas [target + 2].currentHp + " - " + charDatas [currentTurn - 1].currentHp);
					}
				}
				if (currentAction == "dance3") {	// /\
					if (upStage || upStageCount == 0)	{
						Debug.Log ("Player 1 is Exhausted!");
					}
					if (!upStage && upStageCount != 0) {
						upStage = true;
						upStageCount = 3;
						Debug.Log ("Upstage");		//Skip all enemies' turns
					}
				}
			}
			///////////////////////////////////////////////////////////////
			if (currentTurn == 2) {			//PC2
				if (currentAction == "dance1") {
					if (flawless) {
						for (int i = 0; i < 3; i++) {
							charDatas [i].currentHp += 12;
							Debug.Log ("FLAWLESS TEAMHEAL Dance: " + charDatas [i].currentHp);
						}
					} else {
						for (int i = 0; i < 3; i++) {
							charDatas [i].currentHp += 8;
							Debug.Log ("TEAMHEAL Dance: " + charDatas [i].currentHp);
						}
					}
				}
				if (currentAction == "dance2") {
					if (flawless) {
						charDatas [target + 2].currentHp -= 12;
						charDatas [currentTurn - 1].currentHp += 8;
						Debug.Log ("FLAWLESS VAMP Dance: " + charDatas [target + 2].currentHp + " - " + charDatas [currentTurn - 1].currentHp);
					} else {
						charDatas [target + 2].currentHp -= 8;
						charDatas [currentTurn - 1].currentHp += 5;
						Debug.Log ("VAMP Dance: " + charDatas [target + 2].currentHp + " - " + charDatas [currentTurn - 1].currentHp);
					}
				}
				if (currentAction == "dance3") {
					if (miracleUsed) {
						Debug.Log ("Miracle has already been used this battle!");
					}
					if (!miracleUsed) {
						if (flawless) {
							for (int i = 0; i < 3; i++) {
								charDatas [i].currentHp += 28;
								Debug.Log ("FLAWLESS MIRACLE Dance: " + charDatas [i].currentHp);
							}
						} else {
							for (int i = 0; i < 3; i++) {
								charDatas [i].currentHp += 20;
								Debug.Log ("MIRACLE Dance: " + charDatas [i].currentHp);
							}
						}
						miracleUsed = true;
					}
				}
			}
			///////////////////////////////////////////////////////////////
			if (currentTurn == 3) {			//PC3
				if (currentAction == "dance1") {
					if (flawless) {
						charDatas [currentTurn - 1].currentHp += 16;
						Debug.Log ("FLAWLESS SELFHEAL Dance: " + charDatas [currentTurn - 1].currentHp);
					} else {
						charDatas [currentTurn - 1].currentHp += 12;
						Debug.Log ("SELFHEAL Dance: " + charDatas [currentTurn - 1].currentHp);
					}
				}
				if (currentAction == "dance2") {
					if (flawless) {
						charDatas [currentTurn - 1].fightDam += 12;
						Debug.Log ("FLAWLESS REV UP: Fight Damage Increased!");
					} else {
						charDatas [currentTurn - 1].fightDam += 8;
						Debug.Log ("REV UP: Fight Damage Increased!");
					}
				}
				if (currentAction == "dance3") {
					stirThePot = true;
					Debug.Log ("StirThePot");
				}
			}

			currentTurn++;
			turnFinished = false;
			currentMenu = "";
			currentAction = "";
			turnUpdate = true; //for rhythm mechanic
			turnChangedThisFrame = true;
		}
	}
}