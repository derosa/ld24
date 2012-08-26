using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpPower = 200f;
	public float playerSpeed = 100.0f;
	private bool canJump = true;
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
			/*Vector3 newPos = transform.position;
			newPos.x += playerSpeed * Time.deltaTime * axis;
			newPos.x = Mathf.Clamp (newPos.x, 0f, ScreenInfo.GetInstance ().Width () - rage.GetSizeX ());
			transform.position = newPos;
			*/
			if (transform.position.x < 0 || transform.position.x > ScreenInfo.GetInstance ().Width () - rage.GetSizeX ()) {
				rigidbody.velocity = Vector3.zero;
				Vector3 newPos = transform.position;
				newPos.x = Mathf.Clamp (newPos.x, 0f, ScreenInfo.GetInstance ().Width () - rage.GetSizeX ());
				transform.position = newPos;
			}

			Vector3 newVelocity = new Vector3 (axis * playerSpeed, rigidbody.velocity.y, 0.0f);
			rigidbody.velocity = newVelocity;
			
			if (axis < 0.0f) {
				rage.SetHorizontalFlip (true);
			} else {
				rage.SetHorizontalFlip (false);
			}
		}
		
		if (Input.GetAxis ("Vertical") > 0.0f && canJump) {
			rigidbody.AddForce (Vector3.up * jumpPower, ForceMode.VelocityChange);
			canJump = false;
		}
		
		if (transform.position.y < 0.0f) {
			transform.position = initialPosition;
			rigidbody.velocity = Vector3.zero;
			GameObject.FindGameObjectWithTag ("GameController").SendMessage ("ResetGame");
		}
		
	}
	
	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.CompareTag ("ground")) {
			Vector3 newVel = rigidbody.velocity;
			newVel.y = 0.0f;
			rigidbody.velocity = newVel;
			canJump = true;		
		}
		
	}
		
	
	void OnCollisionExit (Collision col)
	{
		if (col.transform.CompareTag ("ground")) {
			canJump = false;
		}
	}
	
	public void Reset ()
	{
		gameObject.transform.position = initialPosition;
		rage.SetSprite ("e", 0);
		rage.PlayNamedAnimation ("idle");
	}
	
	
	public void Die ()
	{
		StartCoroutine (DoDie());
	}
	
	IEnumerator DoDie ()
	{
		IRagePixel rage = GetComponent<RagePixelSprite> ();
		rage.StopAnimation ();
		rage.SetSprite ("explosion");
		rage.PlayNamedAnimation ("explode");
		while (rage.isPlaying()) {
			yield return new WaitForSeconds(0.1f);
		}
		yield return 0;
	}
}

