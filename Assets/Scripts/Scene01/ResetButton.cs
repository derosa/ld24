using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {

	void OnMouseDown ()
	{
		foreach (GameObject o in GameObject.FindGameObjectsWithTag("explosive")) {
			o.SendMessage ("Explode", SendMessageOptions.RequireReceiver);
		}
		
		foreach (GameObject o in GameObject.FindGameObjectsWithTag("letter")) {
			o.SendMessage ("Reset");
		}
	}
}
