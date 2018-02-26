using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barsHP : MonoBehaviour {

	public GameObject reticuleStateMachine;

	public Text HP;

	public bool inBattle;

	int i = 0;	//used to check text position to assign correct health levels

	// Use this for initialization
	void Start () {
		HP = this.GetComponent<Text> ();

		if (HP.GetInstanceID() == 9912) {	//Must be updated to match current text objects' positions
			i = 1;
		}
		if (HP.GetInstanceID() == 9858) {
			i = 2;
		}
		if (HP.GetInstanceID() == 10076) {
			i = 3;
		}
		if (HP.GetInstanceID() == 9850) {
			i = 4;
		}
		if (HP.GetInstanceID() == 9870) {
			i = 5;
		}
		if (HP.GetInstanceID() == 10094) {
			i = 6;
		}
	}
	
	// Update is called once per frame
	void Update () {
		inBattle = reticuleStateMachine.GetComponent<stateMachine> ().inBattle;

		if (!inBattle) {
			HP.text = "";
		}

		if (inBattle) {
			//HP.text = reticuleStateMachine.GetComponent<stateMachine> ().charDatas [i].currentHP + "/" +
			//			reticuleStateMachine.GetComponent<stateMachine> ().charDatas [i].maxHP;
		}
	}
}
