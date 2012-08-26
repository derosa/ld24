using UnityEngine;
using System.Collections;

public class Scene09_WinText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	string txt = 
			"Congratulations!\n" +
			"You just defeated 1000 kittens\n" +
			"and helped Evolution stay\n" +
			"on top as a nice #LD48 theme.\n\n" +
			"I hope you enjoyed the game!";
		guiText.text = txt;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
