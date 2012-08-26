using UnityEngine;
using System.Collections;

public class Scene06_GameController : MonoBehaviour {
	public int nextLevel = 0;
	public GameObject door;
	public GameObject letter;
	public RagePixelSpriteSheet rageSpritesheet;
	
	// Use this for initialization
	void Start ()
	{
		RenderSettings.ambientLight = Color.black;
		float margin = door.GetComponent<RagePixelSprite> ().GetSizeX();
			
		door.transform.position = ScreenInfo.GetInstance ().RandomPosition (margin, door.transform.position.z);
		letter.transform.position = ScreenInfo.GetInstance ().RandomPosition (margin, letter.transform.position.z);
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	void ResetGame ()
	{
			
	}
	
	void DoorEntered ()
	{
		Application.LoadLevel(nextLevel);
	}
	
	void LetterCaptured ()
	{
		RagePixelSprite rage = letter.GetComponent<RagePixelSprite> ();
		rage.spriteSheet = rageSpritesheet;
		door.SendMessage ("CanEnter", true);
			
	} 
	
	
}
