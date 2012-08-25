using UnityEngine;
using System.Collections;

public class DinamiteSpawner : MonoBehaviour {
	public GameObject dinamiteObject;
	
	void Start ()
	{
		RagePixelCamera cam = Camera.main.GetComponent<RagePixelCamera> ();
		float width = cam.resolutionPixelWidth / cam.pixelSize;
		float height = cam.resolutionPixelHeight / cam.pixelSize;
		
		float centerX = width * 0.5f;
		float centerY = height * 0.5f;
		
		BoxCollider col = GetComponent<BoxCollider> ();
		float yDiff = height - col.size.y;
		
		Vector3 newPosition = transform.position;
		newPosition.x = centerX;
		newPosition.y = centerY + yDiff * 0.5f;
		transform.position = newPosition;
	}
	
	void OnMouseDown(){
		SpawnAtMousePosition (Input.mousePosition);
	}
	
	void SpawnAtMousePosition (Vector3 pos)
	{
		RagePixelCamera cam = Camera.main.GetComponent<RagePixelCamera> ();
		float width = cam.resolutionPixelWidth / cam.pixelSize;
		float height = cam.resolutionPixelHeight / cam.pixelSize;
		float xPos = pos.x / Screen.width;
		float yPos = pos.y / Screen.height;
		
		//Debug.Log ("Rage camera size: " + width + "x" + height);
		//Debug.Log ("Screen size: " + Screen.width + "x" + Screen.height);
		//Debug.Log ("Porcentajes: " + xPos + ", " + yPos);
		Vector3 spawnPos = new Vector3 (xPos * width, yPos * height, 0);
		
		Instantiate (dinamiteObject, spawnPos, Quaternion.identity);

	}
	
}
