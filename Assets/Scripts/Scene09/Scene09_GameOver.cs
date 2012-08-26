using UnityEngine;
using System.Collections;

public class Scene09_GameOver : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		string text =
			"Oh, so sorry. The kittens got you.\n" +
			"Although you know evolution \nis not reversible\n" +
			"we are giving you the chance.\n" +
			"Will you start again \nor repeat the kittens slaughter?";
		guiText.text = text;
		
	}

}
