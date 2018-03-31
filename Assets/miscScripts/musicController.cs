using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour {

	public AudioSource BGM;
	public AudioSource SFX;

	public AudioClip adventureLoop_BGM;
	public AudioClip troublemakers_BGM;
	public AudioClip battleIntro_BGM;
	public AudioClip battle_BGM;
	public AudioClip victoryIntro_BGM;
	public AudioClip victory_BGM;
	public AudioClip chatter;

	public GameObject Transition;

	bool inBattle;
	bool battleIntroPlayed;
	bool toggleChange = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		inBattle = Transition.GetComponent<ABTransition> ().inBattle;

		if (inBattle) {
			BGM.clip = battleIntro_BGM;
		}

		if (toggleChange) {
			BGM.Play ();
			toggleChange = false;
		}
	}
}
