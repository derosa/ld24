using UnityEngine;
using System.Collections;

public class S02_WinController : MonoBehaviour {
	public int nextLevel;
	public GameObject letter;
	public GameObject door;

	public void LetterCaptured ()
	{
		door.SendMessage("CanEnter", true);
	}
	
	public void ResetGame ()
	{
		letter.SendMessage ("Reset");
		door.SendMessage ("CanEnter", false);
	}
	
	public void DoorEntered ()
	{
		Debug.Log ("Level WIN");	
		Application.LoadLevel(nextLevel);
		
	}
}
