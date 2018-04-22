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
	public GameObject chatterObject;
	public GameObject reticule;

	bool battleIntroPlayed = false;
	bool toggleChange = false;

	bool victoryIntroPlayed = false;
	bool victoryToggleChange = false;
	bool inVictoryScreen = false;

	AudioClip previousClip = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		previousClip = BGM.clip;
		inVictoryScreen = reticule.GetComponent<stateMachine> ().inVictoryScreen;

		if (inVictoryScreen) {
			if (!victoryIntroPlayed && !victoryToggleChange) {
				BGM.loop = false;
				BGM.clip = victoryIntro_BGM;
				victoryIntroPlayed = true;
				if (previousClip != BGM.clip) {
					victoryToggleChange = true;
				}
			}
			else if (victoryIntroPlayed && !victoryToggleChange && !BGM.isPlaying) {
				BGM.loop = true;
				BGM.clip = victory_BGM;
				if (previousClip != BGM.clip) {
					victoryToggleChange = true;
				}
			}

			if (victoryToggleChange) {
				BGM.Play ();
				victoryToggleChange = false;
				Debug.Log ("victoryPlay");
			}
		}

		else if (!inVictoryScreen) {
			bgmFunc ();
		}
	}

	public void bgmFunc ()	{
		
		if (chatterObject.GetComponent<chatterControl> ().babotchatterCount > -1 && !toggleChange && !Transition.GetComponent<ABTransition> ().inBattle) {
			BGM.loop = true;
			BGM.clip = troublemakers_BGM;
			if (previousClip != BGM.clip) {
				toggleChange = true;
			}
		}

		if (Transition.GetComponent<ABTransition> ().inBattle) {
			if (!battleIntroPlayed && !toggleChange) {
				BGM.loop = false;
				BGM.clip = battleIntro_BGM;
				battleIntroPlayed = true;
				if (previousClip != BGM.clip) {
					toggleChange = true;
				}
			}
			else if (battleIntroPlayed && !toggleChange && !BGM.isPlaying) {
				BGM.loop = true;
				BGM.clip = battle_BGM;
				if (previousClip != BGM.clip) {
					toggleChange = true;
				}
			}
		}

		if (toggleChange) {
			BGM.Play ();
			toggleChange = false;
			//Debug.Log ("play");
		}
	}
}
