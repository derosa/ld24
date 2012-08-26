using UnityEngine;
using System.Collections;

public class Scene03_GameController : MonoBehaviour {
	public int numberOfLevels;
	public GameObject[] restartableObjects;
	public GameObject doorSpawner;
	public GameObject player;
	public GameObject letter;
	public GameObject misteryLayer;
	public GUIText againText;
	public int nextLevel;
	
	private int currentLevel = 0;
	private ArrayList doors; // Good doors. No die.
	
	void Start ()
	{
		misteryLayer.active = false;
		againText.enabled = false;
		doors = new ArrayList ();
		for (int t = 0; t < numberOfLevels; t++) {
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
		if (currentLevel >= numberOfLevels) {
			return;
		}
		
		if (IsGoodDoor (w)) {
			Debug.Log ("Puerta buena, pasamos al siguiente");
			currentLevel++;
			if (currentLevel == numberOfLevels) {
				WonGame ();
			} else {
				StartCoroutine (NextLevel ());
			}
		} else {
			StartCoroutine(StartAgain());
		}
	}
	
	
	private void WonGame ()
	{
		Debug.Log ("Letra ganada");
		letter.SetActiveRecursively(true);
		
	}
	

	
	public void LetterCaptured ()
	{
		StartCoroutine (WaitAndLoadNextLevel ());
		
	}

	public IEnumerator WaitAndLoadNextLevel ()
	{
		Debug.Log ("Fase ganado!");
		while (letter.GetComponent<RagePixelSprite>().isPlaying()) {
			yield return new WaitForSeconds(.2f);
		}
		Application.LoadLevel (nextLevel);

	}

	private IEnumerator NextLevel ()
	{
		misteryLayer.active = true;
		misteryLayer.renderer.material.color = Color.black;
		player.SendMessage ("Reset");
		yield return new WaitForSeconds(0.5f);
		misteryLayer.active = false;
		RequestSpawnDoors ();
	}
	
	private void Fade (float value)
	{
		Debug.Log ("Updating... " + value);
		Color c = gameObject.renderer.material.color;
		c.a = value;
		gameObject.renderer.material.color = c;
	}
	
	private IEnumerator StartAgain ()
	{
		Debug.Log ("Puerta MALA. Reiniciar el juego");
		againText.enabled = true;
		player.SendMessage ("Die");
		yield return new WaitForSeconds(1.0f);
		againText.enabled = false;
		player.SendMessage("Reset");
		RequestSpawnDoors ();
		currentLevel = 0;

	}
	
}
