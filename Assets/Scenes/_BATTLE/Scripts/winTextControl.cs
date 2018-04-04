using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winTextControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			this.GetComponent<Text> ().fontSize = 14;
			this.GetComponent<Text> ().text = "Busto:  235/250\n\t\t +30\n\t\t  265/250 XP\n\n\tBUSTO LEVELED UP!\n\n" +
											  "Titania:  200/300\n\t\t   +30\n\t\t     230/300 XP\n\n" +
											  "Herby:  240/300\n\t\t  +30\n\t\t    270/300 XP\n\n";
		}
	}
}
