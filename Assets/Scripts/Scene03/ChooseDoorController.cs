using UnityEngine;
using System.Collections;

public class ChooseDoorController : MonoBehaviour {
	
	private bool canEnter = false;
	
	public void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player")) {
			CanEnter(true);
		}
	}
	
	public void CanEnter (bool can)
	{
		IRagePixel rage = GetComponent<RagePixelSprite> ();
		canEnter = can;
		if (canEnter) {
			rage.PlayNamedAnimation ("open");
			GameObject.FindGameObjectWithTag ("GameController").SendMessage ("ChosenDoor", gameObject.tag);
		} else {
			rage.PlayNamedAnimation ("close");
		}
	}
}
