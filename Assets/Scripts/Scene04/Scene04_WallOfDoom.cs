using UnityEngine;
using System.Collections;

public class Scene04_WallOfDoom : MonoBehaviour {
	public float wallSpeed = 90.0f;
	private Vector3 _initialPosition;
	private bool _move = false;
	
	void Start ()
	{
		_initialPosition = transform.position;
		Reset();
		
	}
	
	void Update ()
	{
		if (_move) {
			transform.Translate (wallSpeed * Time.deltaTime, 0f, 0f);
		}
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player")) {
			Debug.Log ("Matado...");
			other.SendMessage ("Die", true);
			Reset();
		}	
	}
	
	public void Reset ()
	{
		GameObject.FindGameObjectWithTag("GameController").SendMessage("ResetGame");
	}
	
	private void Restart ()
	{
		_move = false;
		transform.position = _initialPosition;
		StopAllCoroutines ();
		StartCoroutine (DoRestartWall ());
	}
	
	private IEnumerator DoRestartWall ()
	{
		yield return new WaitForSeconds(3f);
		
		_move = true;
	}
	
}
