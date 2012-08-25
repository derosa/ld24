using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(BoxCollider))]
public class DoorController : MonoBehaviour {

	public void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player")) {
			collider.enabled = false;
			GameObject.FindGameObjectWithTag ("GameController").SendMessage ("DoorEntered");
		}
	}
}
