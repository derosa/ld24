using UnityEngine;
using System.Collections;

public class GroundGenerator : MonoBehaviour {
	public GameObject groundCell;
	public GameObject letter;
	public GameObject door;
	
	// Use this for initialization
	void Start ()
	{
		RagePixelSprite rage = groundCell.GetComponent<RagePixelSprite> ();
		float screenWidth = ScreenInfo.GetInstance ().Width ();
		float cellWidth = rage.GetSizeX ();
		float nCells = screenWidth / cellWidth;
		int x = 0;
		int hole = Random.Range (2, (int)nCells - 1);
		Vector3 newPosition = groundCell.transform.position;
		newPosition.x = 0.0f;
		newPosition.y = 0.0f;
		while (nCells-- > 0) {
			newPosition.x = x;
			x += rage.GetSizeX ();
			if (nCells == hole || nCells + 1 == hole) {
				Vector3 letterPo = newPosition;
				letterPo.y += rage.GetSizeY () * 3f;
				letter.transform.position = letterPo;
				continue;
			}
			GameObject newCell = Instantiate (groundCell, newPosition, Quaternion.identity) as GameObject;
			rage = newCell.GetComponent<RagePixelSprite> ();
			rage.selectCell (Random.Range (0, 4));
		}
		newPosition.y += door.GetComponent<RagePixelSprite> ().GetSizeY ();
		door.transform.position = newPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
