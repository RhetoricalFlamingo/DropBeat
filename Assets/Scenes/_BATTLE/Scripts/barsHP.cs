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



		//if (HP.GetInstanceID() == 9946) {
		if (this.name == "0_HPcharDatas")	{
			i = 0;
			//Debug.Log ("1");
		}
		//if (HP.GetInstanceID() == 9888) {
		if (this.name == "1_HPcharDatas")	{
			i = 1;
			//Debug.Log ("2");
		}
		//if (HP.GetInstanceID() == 10106) {
		if (this.name == "2_HPcharDatas")	{
			i = 2;
			//Debug.Log ("3");
		}
		//if (HP.GetInstanceID() == 9878) {
		if (this.name == "3_HPcharDatas")	{
			i = 3;
			//Debug.Log ("4");
		}
		//if (HP.GetInstanceID() == 9902) {
		if (this.name == "4_HPcharDatas")	{
			i = 4;
			//Debug.Log ("5");
		}
		//if (HP.GetInstanceID() == 10126) {
		if (this.name == "5_HPcharDatas")	{
			i = 5;
			//Debug.Log ("6");
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
