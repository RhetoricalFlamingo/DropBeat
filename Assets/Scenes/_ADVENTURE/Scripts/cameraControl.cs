using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

	public GameObject player;
	public GameObject textParent;
	//public Text currentText;

	bool INCOMBAT = false;
	bool INADVENTURE = true;
	Vector3 combatCam = new Vector3 (0f, 0f, 0f);
	Vector3 adventureCam = new Vector3 (0f, 0f, 0f);	//make getcomponent of player transform

	int intCounter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (INCOMBAT) {
			transform.position = combatCam;
		}
		if (INADVENTURE) {
			adventureCam = player.transform.position - new Vector3 (0f, 0f, 10f);
			transform.position = adventureCam;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			intCounter++;
		}

		if (intCounter > 0 && intCounter < 100) {
			textParent.SetActive (true);

			if (intCounter == 1) {
				//currentText.text = "Hey! You!\n\n(SPACE)";
			}
			if (intCounter == 2) {
				//currentText.text = ".....\n\n(SPACE)";
			}
			if (intCounter == 3) {
				//currentText.text = "Let's Fight!\n\n(SPACE)"; 
			}
		}
	}
}
