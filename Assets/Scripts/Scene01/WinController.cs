using UnityEngine;
using System.Collections;

public class WinController : MonoBehaviour {
	public GameObject winLayer;
	public GameObject letter;
	public GameObject door;
	
	void Start ()
	{
		letter.GetComponent<RagePixelSprite> ().SetTintColor (ColorUtils.RandomColor ());
		CameraUtils.ResetCamera ();
	}
	

	public void LetterCaptured ()
	{
		door.SendMessage("CanEnter", true);
		
	}
	
	public void DoorEntered ()
	{
		GameObject.FindGameObjectWithTag ("Player").active = false;
		Debug.Log ("Level completed");
		winLayer.SetActiveRecursively (true);
	}
	
	public void ResetGame ()
	{
		door.SendMessage("CanEnter", false);
		letter.SendMessage ("Reset");
		
	}
}
