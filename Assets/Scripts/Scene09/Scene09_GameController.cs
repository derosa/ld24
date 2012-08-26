using UnityEngine;
using System.Collections;

public class Scene09_GameController : MonoBehaviour {
	public GameObject player;	
	public GameObject historyLayer;
	public GameObject gameOverScreen;
	public GameObject winScreen;
	
	public GUIText title;
	public int playerLifes = 10;
	public int catsToKill = 1000;
	
	private int nCats = 10000;
	private int lifes = 10;
	private string evol = "EVOLUTION";
	private bool alreadyDead = false;
	
	void Start ()
	{
		ShowHistoryLayer ();
	}
	
	public void PlayPressed(){
		ResetGame ();
	}
	

	void PlayerHit ()
	{
		Debug.Log ("Pobre");
		lifes--;
		if (lifes < 0 & ! alreadyDead) {
			alreadyDead = true;
			player.SendMessage ("Die", false);
			SendMessage ("DoSpawn", false); // Deja de escupir gatos.
			ShowGameOverScreen (); // Con there's no turn back in evolution.
			return;
		} else {
			UpdateTitle ();
			iTween.ShakePosition (Camera.main.gameObject, Vector3.one * 2, .5f);
			iTween.ShakeScale (player, Vector3.one, 0.5f);
		}
	}

	/* Intro */
	private void ShowHistoryLayer ()
	{
		title.enabled = false;
		
		historyLayer.SetActiveRecursively (true);

	}

	public void OkFromHistoryLayer ()
	{
		historyLayer.SetActiveRecursively (false);
		PlayPressed ();
	}
	
	/*************/
	/* Game over. Play again or start oooover */
	private void ShowGameOverScreen ()
	{
		gameOverScreen.SetActiveRecursively (true);
	}
	
	public void OkFromGameOver ()
	{
		gameOverScreen.SetActiveRecursively (false);
		PlayPressed();
	}
	
	public void RestartFromLevel0 ()
	{
		Application.LoadLevel ("Scene00_LD10_chainReaction");
	}
	
	/*************/
	
	/* Win screen */
	private void GameWin ()
	{	
		SendMessage ("DoSpawn", false);
		foreach (GameObject cat in GameObject.FindGameObjectsWithTag("cat")) {
			Destroy (cat);
		}
		
		winScreen.SetActiveRecursively (true);
	}
	
	public void OkFromGameWin(){
		winScreen.SetActiveRecursively (false);
		PlayPressed();
	}
		
	/*************/
	
	void ResetGame ()
	{
		title.enabled = true;
		evol = "EVOLUTION";
		nCats = catsToKill;
		lifes = playerLifes -1;
		alreadyDead = false;
		UpdateTitle ();
		
		foreach (GameObject cat in GameObject.FindGameObjectsWithTag("cat")) {
			Destroy (cat);
		}
		player.SendMessage ("Reset");
		SendMessage ("DoSpawn", true);
	}
	
	void KilledCat ()
	{
		nCats --;
		if (nCats <= 0) {
			GameWin ();
		}
		
		UpdateTitle ();
		if (nCats < 100) {
			SendMessage ("SetCatSpawnRate", 15);
		} else if (nCats < 300) {
			SendMessage ("SetCatSpawnRate", 9);
		} else if (nCats < 500) {
			SendMessage ("SetCatSpawnRate", 7);
		} else if (nCats < 750) {
			SendMessage ("SetCatSpawnRate", 5);
		} else if (nCats < 900) {
			SendMessage ("SetCatSpawnRate", 3);
		}
	}
	
	private void UpdateTitle ()
	{
		if (lifes < 0) {
			return;
		}
		
		string e = evol.Substring (0, lifes);
		title.text = "LD24 - " + e + " vs " + nCats + " kittens";
	}
	
	
}
