using UnityEngine;
using System.Collections;

public class WinController : MonoBehaviour {
	public GameObject letter;
	private float nextColorChangeTime = 0.0f;
	private float colorChangeInterval = 1f;
	
	
	void Start () {
		letter.GetComponent<RagePixelSprite>().SetTintColor(ColorUtils.RandomColor());
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > nextColorChangeTime) {
			nextColorChangeTime = Time.time + colorChangeInterval;
			letter.GetComponent<RagePixelSprite> ().SetTintColor (ColorUtils.RandomColor ());
		}
		
	}
	
	public void ResetGame ()
	{
		letter.SendMessage ("Reset");
		
	}
}
