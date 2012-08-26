using UnityEngine;
using System.Collections;

public class Scene03_GameController : MonoBehaviour {
	public GameObject[] restartableObjects;
	public GameObject doorSpawner;
	public GameObject player;
	public GameObject letter;
	
	private int nLevels = 1;
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
		if (currentLevel > nLevels) {
			return;
		}
		
		if (IsGoodDoor (w)) {
			Debug.Log ("Puerta buena, pasamos al siguiente");
			currentLevel++;
			if (currentLevel == nLevels) {
				WonGame ();
			} else {
				NextLevel();
			}
		} else {
			Debug.Log ("Puerta MALA. Reiniciar el juego");
			player.SendMessage ("Die");
			RequestSpawnDoors ();
			currentLevel = 0;
		}
	}
	
	
	private void WonGame ()
	{
		Debug.Log ("Letra ganada");
		letter.SetActiveRecursively(true);
		
	}
	
	public void ResetGame ()
	{
		ResetLogic ();
		foreach (GameObject o in restartableObjects) {
			o.SendMessage ("Reset");
		}
	}
	
	public void LetterCaptured ()
	{
		Debug.Log ("Fase ganado!");
	}
	
	private void ResetLogic ()
	{
		
	}

	private void NextLevel ()
	{
		RequestSpawnDoors ();	
	}
	
	
}
