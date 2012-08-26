using UnityEngine;
using System.Collections;

public class Scene04_GroundGenerador : MonoBehaviour {
	
	public GameObject groundCell;
	public GameObject door;
	public GameObject letter;
	public int groundSize = 10;
	public int numberHoles = 4;
	public int numberHills = 4;

	void Start ()
	{
		RagePixelSprite rage = groundCell.GetComponent<RagePixelSprite> ();
		float screenWidth = ScreenInfo.GetInstance ().Width () * groundSize;
		float cellWidth = rage.GetSizeX ();
		float nCells = screenWidth / cellWidth;
		int x = 0;
		Vector3 newPosition = groundCell.transform.position;
		newPosition.x = 0.0f;
		newPosition.y = 0.0f;
		int [] holes = new int[numberHoles];
		int [] hills = new int[numberHills];
		
		Debug.Log ("Cells: " + nCells);
		
		int letterPosition = Random.Range (4, (int)nCells - 4);
		
		for (int t=0; t < numberHoles; t++) {
			holes [t] = Random.Range (4, (int)nCells - 8);
			Debug.Log ("Hole: " + holes [t]);
		}
		
		for (int t=0; t < numberHills; t++) {
			hills [t] = Random.Range (4, (int)nCells - 8);
			Debug.Log ("Hill: " + hills [t]);
		}
		
		while (nCells-- > 0) {
			newPosition.y = 0.0f;
			if (nCells == letterPosition) {
				newPosition.y = rage.GetSizeY();
				letter.transform.position = newPosition;
				continue;
			}
			if (ArrayContains (holes, (int)nCells, numberHoles)) {
				x += rage.GetSizeX () * 2;
				continue;
			}
			if (ArrayContains (hills, (int)nCells, numberHills)) {
				int width = Random.Range (1, 4);
				int height = 0;
				for (int i = 0; i < width; i++) {
					height ++;
					for (int s = 0; s < height*2; s++) {
						Vector3 newCellPos = new Vector3 (x, s * rage.GetSizeY (), newPosition.z);
						CreateGroundCell (newCellPos);
					}
					x += rage.GetSizeX ();
				}				
			}
			newPosition.x = x;
			x += rage.GetSizeX ();
			CreateGroundCell (newPosition);
		}
		
		newPosition.y += door.GetComponent<RagePixelSprite> ().GetSizeY ();
		door.transform.position = newPosition;
	}
	
	private void CreateGroundCell (Vector3 position)
	{
		GameObject newCell = Instantiate (groundCell, position, Quaternion.identity) as GameObject;
		RagePixelSprite rage = newCell.GetComponent<RagePixelSprite> ();
		rage = newCell.GetComponent<RagePixelSprite> ();
		rage.SetSprite ("ground_tiles", Random.Range (0, 4));
	}
	
	
	private bool ArrayContains (int[] a, int n, int size)
	{	
		for (int t=0; t < size; t++) {
			if (a [t] == n) {
				return true;
			}
		}
		return false;
	}
}
