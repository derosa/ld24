using UnityEngine;
using System.Collections;

public static class CameraUtils {
	public static void ResetCamera ()
	{
		Camera.main.GetComponent<RagePixelCamera> ().ResetCamera ();
	}

	
}
