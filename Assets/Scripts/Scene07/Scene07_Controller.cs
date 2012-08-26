using UnityEngine;
using System.Collections;

public class Scene07_Controller : MonoBehaviour {
	public int nextLevel = 0;
	public GameObject exitDoor;
	private bool _monitorPlayerDoorDistance = false;
	
	
	void Start () {
	
	}
	
	void Update ()
	{
		if (_monitorPlayerDoorDistance) {
			Vector3 player = GameObject.FindGameObjectWithTag ("Player").transform.position;
			if (Vector3.Distance (exitDoor.transform.position, player) < 10F) {
			exitDoor.SendMessage ("CanEnter", true);	
			}
		}
		
	}	
	
	public void LetterGrabbed ()
	{
		_monitorPlayerDoorDistance = true;
	
	}
	
	public void DoorEntered ()
	{
		Debug.Log ("Fin del juego");
		Application.LoadLevel(nextLevel);
	}
	
	
}
