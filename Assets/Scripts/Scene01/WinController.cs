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
		door.GetComponent<RagePixelSprite> ().PlayNamedAnimation ("open");
	}
	
	public void DoorEntered ()
	{
		GameObject.FindGameObjectWithTag ("Player").active = false;
		Debug.Log ("Level completed");
		winLayer.SetActiveRecursively (true);
	}
	
	public void ResetGame ()
	{
		
		letter.SendMessage ("Reset");
		
	}
}
