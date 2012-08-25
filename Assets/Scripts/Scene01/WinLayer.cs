using UnityEngine;
using System.Collections;

public class WinLayer : MonoBehaviour {
	public GameObject []disabledObjects;
	public GUIText text;
	// Use this for initialization
	void Start ()
	{
		transform.position = ScreenInfo.GetInstance ().Center ();
		text.active = false;
		gameObject.SetActiveRecursively (false);
		
	}
	
	void Update ()
	{
		text.active = true;
		text.text = "Every Evolution\n" +
			" has a beginning...";
		foreach (GameObject o in disabledObjects) {
			o.SetActiveRecursively (false);
		}
	}
}
