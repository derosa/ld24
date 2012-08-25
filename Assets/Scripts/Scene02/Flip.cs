using UnityEngine;
using System.Collections;

public class Flip : MonoBehaviour {

	void Start ()
	{
		GetComponent<RagePixelSprite> ().SetHorizontalFlip(true);
		
	}
	
}
