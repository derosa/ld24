using UnityEngine;
using System.Collections;

public class ScreenInfo {
	
	private static ScreenInfo _instance;
	
	private static float width;
	private static float height;
	private static Vector3 center;
	
	public static ScreenInfo GetInstance ()
	{	
		if (_instance == null) {
			_instance = new ScreenInfo ();
			RagePixelCamera cam = Camera.main.GetComponent<RagePixelCamera> ();
			width = cam.resolutionPixelWidth / cam.pixelSize;
			height = cam.resolutionPixelHeight / cam.pixelSize;
			center = new Vector3 (width * 0.5f, height * 0.5f, 0f);
		}
		return _instance;
	}
	
	public float Width ()
	{
		return width;
		
	}
	
	public float Height ()
	{
		return height;
	
	}
	
	public Vector3 Center(){
		return center;
	}
	
	
}
