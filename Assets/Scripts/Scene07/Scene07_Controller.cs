using UnityEngine;
using System.Collections;

public class Scene07_Controller : MonoBehaviour {
	public int nextLevel = 0;
	public GameObject exitDoor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}	
	
	public void LetterGrabbed ()
	{
		exitDoor.SendMessage ("CanOpen", true);
	
	}
	
	public void DoorEntered ()
	{
		Debug.Log ("Fin del juego");
	}
	
	
}
