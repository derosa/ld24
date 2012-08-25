using UnityEngine;
using System.Collections;

public class WinningCondition : MonoBehaviour {
	public GameObject winLayer;
	private bool alreadyWon = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool hasWon = true;
		foreach (GameObject o in GameObject.FindGameObjectsWithTag("letter")) {
			SpriteToDstPoint stdp = o.GetComponent<SpriteToDstPoint> ();
			if (!stdp.IsInPlace ()) {
				hasWon = false;
			}
		}
		
		if (hasWon && !alreadyWon) {
			alreadyWon = true;
			Debug.Log ("Won!");
			winLayer.SetActiveRecursively (true);
		} 
	}
}
