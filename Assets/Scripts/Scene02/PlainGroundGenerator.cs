using UnityEngine;
using System.Collections;

public class PlainGroundGenerator : MonoBehaviour {

	public GameObject groundCell;
	public GameObject door;

	void Start ()
	{
		RagePixelSprite rage = groundCell.GetComponent<RagePixelSprite> ();
		float screenWidth = ScreenInfo.GetInstance ().Width ();
		float cellWidth = rage.GetSizeX ();
		float nCells = screenWidth / cellWidth;
		int x = 0;
		Vector3 newPosition = groundCell.transform.position;
		newPosition.x = 0.0f;
		newPosition.y = 0.0f;
		while (nCells-- > 0) {
			newPosition.x = x;
			x += rage.GetSizeX ();
			GameObject newCell = Instantiate (groundCell, newPosition, Quaternion.identity) as GameObject;
			rage = newCell.GetComponent<RagePixelSprite> ();
			rage.SetSprite("ground_tiles", Random.Range (0, 4));
		}
		
		newPosition.y += door.GetComponent<RagePixelSprite> ().GetSizeY ();
		door.transform.position = newPosition;
	}
}
