using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBarFill : MonoBehaviour {

	public GameObject reticuleStateMachine;
	public int barID = 0;
	float quotient = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		quotient = (float)reticuleStateMachine.GetComponent<stateMachine> ().charDatas [barID].currentHp
			/ (float)reticuleStateMachine.GetComponent<stateMachine> ().charDatas [barID].maxHp;

		this.GetComponent<Image> ().fillAmount = quotient;

		//Debug.Log (quotient);
	}
}
