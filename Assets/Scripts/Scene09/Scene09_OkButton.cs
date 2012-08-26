using UnityEngine;
using System.Collections;

public class Scene09_OkButton : MonoBehaviour {
	
	public string msgToSend;
	
	void Start ()
	{
		Debug.Log ("Estoy vivo...");

	}
	
	void OnMouseDown(){
		Debug.Log ("Click");
		GameObject.FindGameObjectWithTag("GameController").SendMessage(msgToSend);
	}
}
