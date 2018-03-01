using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATransition : MonoBehaviour {

	public Vector2 dialogueTrigger = new Vector2 (0f, 0f);
	public GameObject player;

	public bool inBattle = false;

	// Update is called once per frame
	void Update () {
		//if (Vector2.Distance (player.transform.position, dialogueTrigger) < 1 && Input.GetKeyDown (KeyCode.Space) && !inBattle) {
		if (Input.GetKeyDown (KeyCode.Space) && !inBattle)	{
		inBattle = true;
		}
	}
}
