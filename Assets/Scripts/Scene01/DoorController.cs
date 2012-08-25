using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(BoxCollider))]
public class DoorController : MonoBehaviour {
	
	private bool canEnter = false;
	
	public void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player") && canEnter) {
			collider.enabled = false;
			GameObject.FindGameObjectWithTag ("GameController").SendMessage ("DoorEntered");
		}
	}
	
	public void CanEnter (bool can)
	{
		IRagePixel rage = GetComponent<RagePixelSprite> ();
		canEnter = can;
		if (canEnter) {
			rage.PlayNamedAnimation ("open");
		} else {
			rage.PlayNamedAnimation ("close");
		}

		
	}
}
