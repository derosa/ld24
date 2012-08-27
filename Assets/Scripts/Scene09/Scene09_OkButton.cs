using UnityEngine;
using System.Collections;

public class Scene09_OkButton : MonoBehaviour {
	
	public string msgToSend;
	
	
	void OnMouseDown(){
		GameObject.FindGameObjectWithTag("GameController").SendMessage(msgToSend);
	}
}
