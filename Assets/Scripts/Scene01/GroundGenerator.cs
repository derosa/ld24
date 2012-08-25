using UnityEngine;
using System.Collections;

public class GroundGenerator : MonoBehaviour {
	public GameObject groundCell;
	public GameObject letter;
	
	// Use this for initialization
	void Start ()
	{
		RagePixelSprite rage = groundCell.GetComponent<RagePixelSprite> ();
		float screenWidth = ScreenInfo.GetInstance ().Width ();
		float cellWidth = rage.GetSizeX ();
		float nCells = screenWidth / cellWidth;
		int x = 0;
		int hole = Random.Range (2, (int)nCells - 1);
		
		while (nCells-- > 0) {
			Vector3 newPosition = Vector3.zero;
			newPosition.x = x;
			x += rage.GetSizeX ();
			if (nCells == hole || nCells + 1 == hole) {
				Vector3 letterPo = newPosition;
				letterPo.y += rage.GetSizeY() * 3f;
				letter.transform.position = letterPo;
				continue;
			}
			GameObject newCell = Instantiate (groundCell, newPosition, Quaternion.identity) as GameObject;
			rage = newCell.GetComponent<RagePixelSprite> ();
			rage.selectCell (Random.Range (0, 4));
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
