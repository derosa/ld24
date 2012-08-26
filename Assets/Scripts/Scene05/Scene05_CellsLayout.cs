using UnityEngine;
using System.Collections;

public class Scene05_CellsLayout : MonoBehaviour {
	
	public GameObject cell;
	public GameObject winDoor;
	public GameObject letter;
	public GameObject key;
	public GameObject lockedDoor;
	
	
	// D = Door
	// K = Key
	// L = Locked Door
	// A = Letter
	
	private string Cavern 
		= 
			"******************************" + 
			"*  D**  *    ***  * *   **   *" + 
			"*  **    *   *    * **      **" + 
			"**    **   **  **      * *****" + 
			"**  *    * K* *   ******  *  *" + 
			"*  **  ** * **   *  *     * **" + 
			"**  **    *     *     *** L  *" + 
			"***    ** *  **   ****   *** *" + 
			"*           **  ****A  *     *" + 
			"******************************" ;
	
		private string testCavern 
		= 
			"******************************" + 
			"*   **  *    ***  * *   **   *" + 
			"*  **    *   *    * **      **" + 
			"**    **   **  **      * *****" + 
			"**  *    *  * *   ******  *  *" + 
			"*  **  ** * **   *  *     * **" + 
			"**  **    *     *     * *    *" + 
			"***    ** *  **   ****   *** *" + 
			"*   KLAD    **  ****     *   *" + 
			"******************************" ;
			
			
	// Use this for initialization
	void Start ()
	{
		int width = 30;
		int height = 10;
		IRagePixel rage = cell.GetComponent<RagePixelSprite> ();
		
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				char item = Cavern [y * width + x];
				if (item != ' ') {
					GameObject o = cell;
					
					if (item == 'D') {
						o = winDoor;
					} else if (item == 'K') {
						o = key;
					} else if (item == 'L') {
						o = lockedDoor;
					} else if (item == 'A') {
						o = letter;
					}
					int newY = height - y;
					
					Vector3 newPos = new Vector3 (x * rage.GetSizeX (), newY * rage.GetSizeY (), o.transform.position.z);
					if (o == cell) {
						GameObject newCell = Instantiate (o, newPos, Quaternion.identity) as GameObject;
						newCell.transform.parent = transform;
					} else {
						o.transform.position = newPos;
					}
					
				} 
				
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
