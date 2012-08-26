using UnityEngine;
using System.Collections;

public class Scene05_LockedDoorController : MonoBehaviour {

	private bool canOpen = false;
	private bool alreadyOpen = false;
	IRagePixel rage;
	
	void Start ()
	{
		rage = GetComponent<RagePixelSprite> ();
	}
	
	
	public void Update ()
	{
		if (canOpen && alreadyOpen) {
			GetComponent<BoxCollider> ().enabled = false;
		}
	}
	public void OnCollisionEnter (Collision other)
	{
		Debug.Log ("Locked door trigger by " + other.gameObject.tag);
		if (other.gameObject.CompareTag ("Player") && !alreadyOpen) {
			alreadyOpen = true;
			rage.PlayNamedAnimation ("open");
		}
	}

	public void CanOpen (bool can)
	{
		canOpen = can;
	}
	
	
	
}
