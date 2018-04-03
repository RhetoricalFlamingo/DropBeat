using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

	public GameObject ABTran;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ABTran.GetComponent<ABTransition> ().inBattle) {
		//	this.GetComponent<Camera> ().rect = new Rect (0, 50, 0, 1);
		}

	}
}
