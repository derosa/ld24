using UnityEngine;
using System.Collections;

public class Screen09_PlayerController : MonoBehaviour {
	
	public float playerSpeed = 100.0f;
	public float fireRate = 10.0f;
	
	public GameObject bullet;
	
	private Vector3 initialPosition;
	private RagePixelSprite rage;
	private bool flipped = false;
	
	private Vector3 target = Vector3.zero;
	private bool _alreadyDead = false;
	
	void Start ()
	{
		Physics.gravity = new Vector3 (0f, -980f, 0f);
		initialPosition = transform.position;
		rage = GetComponent<RagePixelSprite> ();
		rage.PlayNamedAnimation("idle");
	}
	
	void Update ()
	{
		UpdateKeyboardInput ();
		UpdateMouseInput ();
		UpdateFire();
	}	
	
	private void UpdateKeyboardInput ()
	{
		float axis = Input.GetAxis ("Horizontal");
		if (axis != 0.0f) {
			Vector3 newPos = transform.position;
			newPos.x += playerSpeed * Time.deltaTime * axis;
			newPos.x = Mathf.Clamp (newPos.x, rage.GetSizeX () * 0.5f, 
				ScreenInfo.GetInstance ().Width () - rage.GetSizeX () * 0.5f);
			transform.position = newPos;
		}
		
		axis = Input.GetAxis ("Vertical");
		if (axis != 0.0f) {
			Vector3 newPos = transform.position;
			newPos.y += playerSpeed * Time.deltaTime * axis;
			newPos.y = Mathf.Clamp (newPos.y, rage.GetSizeY () * 0.5f, ScreenInfo.GetInstance ().Height () - rage.GetSizeY () * 0.5f);
			transform.position = newPos;
		}
	}
	
	private void UpdateMouseInput ()
	{
		target = ScreenInfo.GetInstance ().ScreenCoordToGame (Input.mousePosition);
		flipped = target.x < transform.position.x;
		rage.SetHorizontalFlip (flipped);
	}
	
	private void UpdateFire ()
	{
		if (Input.GetButtonDown ("Fire1")) {
			Fire ();
		}
	}
	
	public void Fire ()
	{
		Vector3 direction;
		if (flipped) {
			direction = Vector3.left;
		} else {
			direction = Vector3.right;
		}
		direction *= rage.GetSizeX () * 0.75f;
		GameObject b = Instantiate (bullet, transform.position + direction, Quaternion.identity) as GameObject;
		b.SendMessage ("SetTarget", target);
		SendMessage("SoundLaser");
	}
	
	public void Reset ()
	{
		gameObject.transform.position = initialPosition;
		rage.SetSprite ("e", 0);
		rage.PlayNamedAnimation ("idle");
		_alreadyDead = false;
	}
	
	public void Die (bool andReset=false)
	{
		if (!_alreadyDead) {
			audio.SendMessage("SoundDie");
			_alreadyDead = true;
			StartCoroutine (DoDie (andReset));
		}
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
