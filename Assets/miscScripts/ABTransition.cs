using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABTransition : MonoBehaviour {

	public bool inBattle;
	public GameObject ATran;
	public GameObject chatter;

	public Vector3 adventureCam = new Vector3 (0, 0, -10);
	public Vector3 battleCam = new Vector3 (0, 0, -10);
	public GameObject cam;

	// Use this for initialization
	void Start () {
		adventureCam = cam.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (chatter.GetComponent<chatterControl> ().transitionTrigger) {
			inBattle = true;
		}

		if (inBattle) {
			cam.transform.position = battleCam;
			cam.GetComponent<Camera> ().orthographicSize = 12;
		}
		if (!inBattle)
			cam.transform.position = adventureCam;
	}
}
