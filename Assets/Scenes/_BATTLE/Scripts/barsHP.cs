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



		if (HP.GetInstanceID() == 9942) {
			i = 0;
			Debug.Log ("1");
		}
		if (HP.GetInstanceID() == 9884) {
			i = 1;
			Debug.Log ("2");
		}
		if (HP.GetInstanceID() == 10108) {
			i = 2;
			Debug.Log ("3");
		}
		if (HP.GetInstanceID() == 9874) {
			i = 3;
			Debug.Log ("4");
		}
		if (HP.GetInstanceID() == 9898) {
			i = 4;
			Debug.Log ("5");
		}
		if (HP.GetInstanceID() == 10126) {
			i = 5;
			Debug.Log ("6");
		}
	}
	
	// Update is called once per frame
	void Update () {
		inBattle = reticuleStateMachine.GetComponent<stateMachine> ().inBattle;

		if (!inBattle) {
			HP.text = "";
		}

		if (inBattle) {
			HP.text = reticuleStateMachine.GetComponent<stateMachine> ().charDatas [i].currentHp + "/" +
						reticuleStateMachine.GetComponent<stateMachine> ().charDatas [i].maxHp;
		}
	}
}
