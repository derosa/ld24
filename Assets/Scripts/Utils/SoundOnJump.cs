using UnityEngine;
using System.Collections;

public class SoundOnJump : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetButtonDown ("Jump") && GetComponent<CharacterController>().isGrounded) {
		audio.Play ();
		}
	}
}
