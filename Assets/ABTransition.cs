using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABTransition : MonoBehaviour {

	public bool inBattle;
	public GameObject ATran;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		inBattle = ATran.GetComponent<ATransition> ().inBattle;
	}
}
