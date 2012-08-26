using UnityEngine;
using System.Collections;

public class Scene05_GameController : MonoBehaviour {
	public GameObject player;
	public GameObject winDoor;
	public GameObject letter;
	public GameObject key;
	public GameObject lockedDoor;
	public int nextLevel = 0;
	
	public void ResetGame ()
	{
		
	}
	public void LetterCaptured ()
	{
		winDoor.SendMessage("CanEnter", true);
	}
	
	public void KeyGrabbed ()
	{
		lockedDoor.SendMessage ("CanOpen", true);
	}
	
	public void DoorEntered ()
	{
		Application.LoadLevel(nextLevel);

	}
}
