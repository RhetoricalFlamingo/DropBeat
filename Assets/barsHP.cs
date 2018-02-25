using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barsHP : MonoBehaviour {

	public GameObject reticuleStateMachine;

	public Text HP;

	int i = 0;	//used to check text position to assign correct health levels

	// Use this for initialization
	void Start () {
		HP = this.GetComponent<Text> ();

		if (transform.position.x == -43) {	//Must be updated to match current text objects' positions
			i = 1;
		}
		if (transform.localPosition.x == -96.78001) {
			i = 2;
		}
		if (transform.localPosition.x == -118.78) {
			i = 3;
		}
		if (transform.localPosition.x == 48.2) {
			i = 4;
		}
		if (transform.localPosition.x == 80.1) {
			i = 5;
		}
		if (transform.localPosition.x == 124.3) {
			i = 6;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//HP.text = reticuleStateMachine.GetComponent<stateMachine> ().charDatas [i].currentHP;
	}
}
