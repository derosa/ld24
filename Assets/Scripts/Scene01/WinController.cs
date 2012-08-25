using UnityEngine;
using System.Collections;

public class WinController : MonoBehaviour {
	public GameObject letter;
	
	void Start () {
		letter.GetComponent<RagePixelSprite>().SetTintColor(ColorUtils.RandomColor());
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public void ResetGame ()
	{
		letter.SendMessage ("Reset");
		
	}
}
