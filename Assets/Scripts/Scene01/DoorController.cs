using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(BoxCollider))]
public class DoorController : MonoBehaviour {
	
	private bool canEnter = false;
	
	public void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Winning door trigger by " + other.gameObject.tag);
		if (other.CompareTag ("Player") && canEnter) {
			collider.enabled = false;
			GameObject.FindGameObjectWithTag ("GameController").SendMessage ("DoorEntered");
		}
	}
	
	public void CanEnter (bool can)
	{
		if (canEnter == can) {
			return;
		}
		//Debug.Log ("Door: Can Enter: " + can);
		
		IRagePixel rage = GetComponent<RagePixelSprite> ();
		canEnter = can;
		if (canEnter) {
			rage.PlayNamedAnimation ("open");
		} else {
			rage.PlayNamedAnimation ("close");
		}

		
	}
}
