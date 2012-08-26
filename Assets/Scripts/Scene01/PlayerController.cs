using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpPower = 200f;
	public float playerSpeed = 100.0f;
	private Vector3 initialPosition;
	private IRagePixel rage;
	private Vector3 velocity = Vector3.zero;
	private CharacterController controller;
	
	void Start ()
	{
		Physics.gravity = new Vector3 (0f, -980f, 0f);
		initialPosition = transform.position;
		rage = GetComponent<RagePixelSprite> ();
		controller = GetComponent<CharacterController>();	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float axis = Input.GetAxis ("Horizontal");
		if (axis != 0.0f) {
			/*Vector3 newPos = transform.position;
			newPos.x += playerSpeed * Time.deltaTime * axis;
			newPos.x = Mathf.Clamp (newPos.x, 0f, ScreenInfo.GetInstance ().Width () - rage.GetSizeX ());
			transform.position = newPos;
			*/
			
			velocity = new Vector3 (playerSpeed * axis, velocity.y, 0.0f);
			
				
			//Vector3 newVelocity = new Vector3 (axis * playerSpeed, rigidbody.velocity.y, 0.0f);
			//rigidbody.velocity = newVelocity;
			
			if (axis < 0.0f) {
				rage.SetHorizontalFlip (true);
			} else {
				rage.SetHorizontalFlip (false);
			}
		}
		
		if (Input.GetAxis ("Vertical") > 0.0f && controller.isGrounded) {
			//Debug.Log ("Salta");
			velocity.y = jumpPower;
			//rigidbody.AddForce (Vector3.up * jumpPower, ForceMode.VelocityChange);
			//canJump = false;
		}
		velocity.y += Physics.gravity.y * Time.deltaTime;

		controller.Move (velocity * Time.deltaTime);
		/*	
		if (transform.position.x < 0 || transform.position.x > ScreenInfo.GetInstance ().Width () - rage.GetSizeX ()) {
			//rigidbody.velocity = Vector3.zero;
			velocity = Vector3.zero;
			Vector3 newPos = transform.position;
			newPos.x = Mathf.Clamp (newPos.x, 0f, ScreenInfo.GetInstance ().Width () - rage.GetSizeX ());
			transform.position = newPos;
		}
		 
		 */
		
		if (transform.position.y < -rage.GetSizeY () * 5f) {
			transform.position = initialPosition;
			velocity = Vector3.zero;
			GameObject.FindGameObjectWithTag ("GameController").SendMessage ("ResetGame");
		}
		
	}
	
	
	public void Reset ()
	{
		gameObject.transform.position = initialPosition;
		rage.SetSprite ("e", 0);
		rage.PlayNamedAnimation ("idle");
	}
	
	
	public void Die (bool andReset=false)
	{
		StartCoroutine (DoDie(andReset));
	}
	
	IEnumerator DoDie (bool andReset)
	{
		IRagePixel rage = GetComponent<RagePixelSprite> ();
		rage.StopAnimation ();
		rage.SetSprite ("explosion");
		rage.PlayNamedAnimation ("explode");
		while (rage.isPlaying()) {
			yield return new WaitForSeconds(0.1f);
		}
		if (andReset) {
			Reset ();
		}
		yield return 0;
	}
}

