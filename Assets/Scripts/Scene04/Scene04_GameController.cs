using UnityEngine;
using System.Collections;

public class Scene04_GameController : MonoBehaviour {
	
	public GameObject player;
	public GameObject door;
	public GameObject wall;
	public GameObject letter;
	
	public int nextLevel = 5;
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Vector3.Distance (player.transform.position, wall.transform.position) < ScreenInfo.GetInstance ().Width ()) {
			if (!player.transform.GetChild (0).gameObject.active) {
				player.transform.GetChild (0).gameObject.active = true;
			}
		} else if (player.transform.GetChild (0).gameObject.active) {
			player.transform.GetChild (0).gameObject.active = false;
		}
	}
	
	public void  DoorEntered ()
	{
		Debug.Log ("Game won!");
		Application.LoadLevel (nextLevel);
	}

	public void ResetGame ()
	{
		GameObject.FindGameObjectWithTag ("Wall").SendMessage ("Reset");
		letter.SendMessage ("Reset");
		door.SendMessage ("CanEnter", false);
	}

	public void LetterCaptured ()
	{
		door.SendMessage ("CanEnter", true);	
	}
	
	
	
}
