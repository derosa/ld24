using UnityEngine;
using System.Collections;

public class Scene07_Controller : MonoBehaviour {
	public int nextLevel = 0;
	public GameObject exitDoor;
	private bool canOpenDoor = false;
	
	
	
	public void LetterGrabbed ()
	{
		canOpenDoor = true;
	
	}
	
	public void DoorEntered ()
	{
		Debug.Log ("Fin del juego");
		Application.LoadLevel (nextLevel);
	}
	
	public void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player") && canOpenDoor) {
			exitDoor.SendMessage ("CanEnter", true);	
		}
	}
	
	
	
}
