using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chatterControl : MonoBehaviour {
	int babotchatterCount = -1;
	//int babotSize = 8;
	string[] babot = new string[8];

	int npc1chatterCount = -1;
	//int npc1Size = 3;
	string[] npc1 = new string[3];

	int npc2chatterCount = -1;
	//int npc2Size = 2;
	string[] npc2 = new string[2];

	int npc3chatterCount = -1;
	//int npc3Size = 2;
	string[] npc3 = new string[2];

	public GameObject player;
	public bool nearBabot = false;
	public bool nearNpc1 = false;
	public bool nearNpc2 = false;
	public bool nearNpc3 = false;

	public GameObject textBackerTop;
	public GameObject textBackerTop2;
	public GameObject textBackerBot;
	public GameObject textBackerBot2;
	public GameObject botText;
	public GameObject botText2;
	public GameObject topText;
	public GameObject topText2;

	// Use this for initialization
	void Start () {
		loadDialogue ();
	}
	
	// Update is called once per frame
	void Update () {
		proximityCheck ();

		if (Input.GetKeyDown (KeyCode.E)) {
			if (nearBabot) {
				babotchatterCount++;
				textBackerBot.SetActive (true);

				botText.GetComponent<TextMesh> ().text = babot [babotchatterCount];
				botText.SetActive (true);
			}

			if (nearNpc1) {
				npc1chatterCount++;
				textBackerBot2.SetActive (true);
				botText2.SetActive (true);

				botText2.GetComponent<TextMesh> ().text = npc1 [npc1chatterCount];
				botText2.SetActive (true);
			}

			if (nearNpc2) {
				npc2chatterCount++;
				textBackerTop.SetActive (true);
				topText.SetActive (true);

				topText.GetComponent<TextMesh> ().text = npc2 [npc2chatterCount];
				topText.SetActive (true);
			}

			if (nearNpc3) {
				npc3chatterCount++;
				textBackerTop2.SetActive (true);
				topText2.SetActive (true);

				topText2.GetComponent<TextMesh> ().text = npc3 [npc3chatterCount];
				topText2.SetActive (true);
			}
		}

	}

	void proximityCheck ()	{
		nearBabot = player.GetComponent<PlayerMover_ADV> ().nearBabot;
		if (!nearBabot) {
			textBackerBot.SetActive (false);
			botText.SetActive (false);
		}

		nearNpc1 = player.GetComponent<PlayerMover_ADV> ().nearNpc1;
		if (!nearNpc1) {
			textBackerBot2.SetActive (false);
			botText2.SetActive (false);
		}

		nearNpc2 = player.GetComponent<PlayerMover_ADV> ().nearNpc2;
		if (!nearNpc2) {
			textBackerTop.SetActive (false);
			topText.SetActive (false);
		}

		nearNpc3 = player.GetComponent<PlayerMover_ADV> ().nearNpc3;
		if (!nearNpc3) {
			textBackerTop2.SetActive (false);
			topText2.SetActive (false);
		}
	}


	void loadDialogue ()	{
		babot[0] = "HEY! YOU!";
		babot[1] = "Don't you know who\nwe are??";
		babot[2] = "......You don't?";
		babot[3] = ".....................";
		babot[4] = "...WE are the Babots,\nthe raddest dancemeisters\nin the YARD!";
		babot[5] = "And if you don't give us\nroom to dance, we'll\nSHUT YOU DOWN.";
		babot[6] = "Go talk to the wallflowers\nor something; don't\nbother us again.";
		babot[7] = "Alright, you asked for it...\nBABOTS: G E T  F U N K Y!";

		npc1[0] = "Those dang Babots ain't\ngot no rhythm...";
		npc1[1] = "Try only pressing buttons\non the beat to get\nan edge!";
		npc1[2] = "You'll know if you got it\ncause you'll see\nthe word 'FLAWLESS'";

		npc2[0] = "Go with the flow, don't\nworry about the music";
		npc2[1] = "You have as long as you\nwant to take your turn!";

		npc3[0] = "Did you know Babots pick\ntheir moves almost\ncompletely at random?";
		npc3[1] = "That's right! They're\ncomplete idiots!";
	}
}
