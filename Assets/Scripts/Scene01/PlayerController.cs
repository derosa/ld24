using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private float speed = 100.0f;
	private bool jumping = false;
	private Vector3 initialPosition;
	private IRagePixel rage;
	
	void Start ()
	{
		Physics.gravity = new Vector3 (0f, -980f, 0f);
		initialPosition = transform.position;
		rage = GetComponent<RagePixelSprite>();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float axis = Input.GetAxis ("Horizontal");
		if (axis != 0.0f) {
			Vector3 newPos = transform.position;
			newPos.x += speed * Time.deltaTime * axis;
			transform.position = newPos;
			if (axis < 0.0f) {
				rage.SetHorizontalFlip (true);
			} else {
				rage.SetHorizontalFlip (false);
			}
		}
		
		axis = Input.GetAxis ("Vertical");
		if (axis > 0.0f && !jumping) {
			rigidbody.AddForce (Vector3.up * 200f, ForceMode.VelocityChange);
			jumping = true;
		}
		
		if (transform.position.y < 0.0f) {
			transform.position = initialPosition;
			rigidbody.velocity = Vector3.zero;
			GameObject.FindGameObjectWithTag("GameController").SendMessage("ResetGame");
		}
		
	}
	
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.CompareTag ("ground")) {
			Vector3 newVel = rigidbody.velocity;
			newVel.y = 0.0f;
			rigidbody.velocity = newVel;
		}
	}
		
	
	void OnCollisionStay (Collision col)
	{
		
		if (col.gameObject.CompareTag ("ground")) {
			jumping = false;
		}
	}
	
	void OnCollisionExit (Collision col)
	{
		
		if (col.transform.CompareTag ("ground")) {
			jumping = true;
		}
	}
}
