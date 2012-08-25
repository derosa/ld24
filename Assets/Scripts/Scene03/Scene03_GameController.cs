using UnityEngine;
using System.Collections;

public class Scene03_GameController : MonoBehaviour {
	public GameObject[] restartableObjects;
	public GameObject doorSpawner;
	
	private int nLevels = 3;
	private int currentLevel = 0;
	private ArrayList doors; // Good doors. No die.
	
	void Start ()
	{
		doors = new ArrayList ();
		for (int t = 0; t < nLevels; t++) {
			string goodDoor = Random.value < 0.5f ? "left" : "right";
			doors.Add (goodDoor);
			Debug.Log ("Good door: " + goodDoor);
		}
		
		RequestSpawnDoors ();
		
	}
	
	private void RequestSpawnDoors ()
	{
		// New doors, parameter indicates the good one.
		doorSpawner.SendMessage ("SpawnDoors");
	}
	
	private bool IsGoodDoor (string chosenDoor)
	{
		return doors[currentLevel].Equals(chosenDoor);
	}
	
	public void ChosenDoor (string w)
	{
		if (IsGoodDoor (w)) {
			Debug.Log ("Puerta buena, pasamos al siguiente");
			currentLevel++;
			RequestSpawnDoors();
		} else {
			Debug.Log ("Puerta MALA. Reiniciar el juego");
		}
	}
	
	
	
	
	
	public void ResetGame ()
	{
		ResetLogic ();
		foreach (GameObject o in restartableObjects) {
			o.SendMessage ("Reset");
		}
	}
	
	private void ResetLogic(){
		
	}
}
