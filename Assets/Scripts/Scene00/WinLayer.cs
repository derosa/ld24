using UnityEngine;
using System.Collections;

public class WinLayer : MonoBehaviour {
	public GameObject []disabledObjects;
	public GUIText text;
	public GameObject nextButton;
	
	// Use this for initialization
	void Start ()
	{
		transform.position = ScreenInfo.GetInstance ().Center ();
		text.gameObject.active = false;
		Vector3 newPos = ScreenInfo.GetInstance ().Center ();
		newPos.y = nextButton.GetComponent<RagePixelSprite>().GetSizeY();
		nextButton.transform.position = newPos;
		nextButton.gameObject.active = false;
		
		gameObject.SetActiveRecursively (false);
		
	}
	
	void Update ()
	{
		text.gameObject.active = true;
		nextButton.gameObject.active = true;
		text.text = "Every Evolution\n" +
			" has a beginning...";
		foreach (GameObject o in disabledObjects) {
			o.SetActiveRecursively (false);
		}
	}
}
