using UnityEngine;
using System.Collections;

public class ScreenInfo {
	
	private static ScreenInfo _instance;
	
	private static float width;
	private static float height;
	private static Vector3 center;
	private static Rect screenRect;
	
	public static ScreenInfo GetInstance ()
	{	
		if (_instance == null) {
			_instance = new ScreenInfo ();
			RagePixelCamera cam = Camera.main.GetComponent<RagePixelCamera> ();
			width = cam.resolutionPixelWidth / cam.pixelSize;
			height = cam.resolutionPixelHeight / cam.pixelSize;
			center = new Vector3 (width * 0.5f, height * 0.5f, 0f);
			screenRect = new Rect(0, 0, width, height);
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
	
	public Vector3 Center ()
	{
		return center;
	}
	
	public Vector3 ScreenCoordToGame (Vector3 pos)
	{
		float xPos = pos.x / Screen.width;
		float yPos = pos.y / Screen.height;
		Vector3 p = new Vector3 (xPos * width, yPos * height, 0f);
		return p;
	}
	
	public Vector3 RandomPosition (float margin, float z)
	{
		float x = Random.Range (margin, width - margin);
		float y = Random.Range (margin, height - margin);
		return new Vector3 (x, y, z);
	}
	
	public bool InScreen(Vector3 p){
		return screenRect.Contains(p);
	}
	
	
	
}
