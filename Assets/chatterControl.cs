using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chatterControl : MonoBehaviour {
	int babotchatterCount = 0;
	string babot_1 = "HEY! YOU!";
	string babot_2 = "Don't you know who we are??";
	string babot_3 = "......You don't?";
	string babot_4 = ".....................";
	string babot_5 = "...WE are the Babots, the raddest dancemeisters in the YARD!";
	string babot_6 = "And if you don't give us room to dance, we'll SHUT YOU DOWN.";
	string babot_7 = "Go talk to the wallflowers or something; don't bother us again.";
	string babot_8 = "Alright, you asked for it...BABOTS: G E T  F U N K Y!";

	int npc1chatterCount = 0;
	string npc11 = "Those dang Babots ain't got no rhythm...";
	string npc12 = "Try only pressing buttons on the beat to get an edge!";
	string npc13 = "You'll know if you got it cause you'll see the word 'FLAWLESS'";

	int npc2chatterCount = 0;
	string npc21 = "Go with the flow, don't worry about the music";
	string npc22 = "You have as long as you want to take your turn!";

	int npc3chatterCount = 0;
	string npc31 = "Did you know Babots pick their moves almost completely at random?";
	string npc32 = "That's right! They're complete idiots!";

	public GameObject player;
	public bool nearBabot = false;
	public bool nearNpc1 = false;
	public 	bool nearNpc2 = false;
	public 	bool nearNpc3 = false;

	public GameObject textBackerTop;
	public GameObject textBackerBot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		proximityCheck ();

		if (Input.GetKeyDown (KeyCode.E)) {
			if (nearBabot) {
				babotchatterCount++;
				textBackerBot.SetActive (true);
				Debug.Log ("babotTalk");
			}

			if (nearNpc1) {
				npc1chatterCount++;
				textBackerBot.SetActive (true);
			}

			if (nearNpc2) {
				npc2chatterCount++;
				textBackerTop.SetActive (true);
			}

			if (nearNpc3) {
				npc3chatterCount++;
				textBackerTop.SetActive (true);
			}
		}
	}

	void proximityCheck ()	{
		nearBabot = player.GetComponent<PlayerMover_ADV> ().nearBabot;
		if (!nearBabot) {
			textBackerBot.SetActive (false);
		}

		nearNpc1 = player.GetComponent<PlayerMover_ADV> ().nearNpc1;
		if (!nearNpc1) {
			textBackerBot.SetActive (false);
		}

		nearNpc2 = player.GetComponent<PlayerMover_ADV> ().nearNpc2;
		if (!nearNpc2) {
			textBackerTop.SetActive (false);
		}

		nearNpc3 = player.GetComponent<PlayerMover_ADV> ().nearNpc3;
		if (!nearNpc3) {
			textBackerTop.SetActive (false);
		}
	}
}
