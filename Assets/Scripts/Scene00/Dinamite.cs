using UnityEngine;
using System.Collections;

public class Dinamite : AnimableObject {
	
	IRagePixel rage;
	Vector3 lastPosition;
	
	void Start ()
	{
		rage = GetComponent<RagePixelSprite> ();
		rage.PlayNamedAnimation("idle");
	}
	
	public void Explode ()
	{	
		audio.Play ();
		AnimateAndDestroy (gameObject, "explosion");

	}	
}
