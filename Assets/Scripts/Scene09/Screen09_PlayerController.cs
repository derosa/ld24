using UnityEngine;
using System.Collections;

public class Screen09_PlayerController : MonoBehaviour {
	
	public float playerSpeed = 100.0f;
	public float fireRate = 10.0f;
	
	public GameObject bullet;
	
	private Vector3 initialPosition;
	private IRagePixel rage;
	
	private Vector3 target = Vector3.zero;
	
	void Start ()
	{
		Physics.gravity = new Vector3 (0f, -980f, 0f);
		initialPosition = transform.position;
		rage = GetComponent<RagePixelSprite> ();
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
			newPos.x = Mathf.Clamp (newPos.x, 0f, ScreenInfo.GetInstance ().Width () - rage.GetSizeX ());
			transform.position = newPos;
		}
		
		axis = Input.GetAxis ("Vertical");
		if (axis != 0.0f) {
			Vector3 newPos = transform.position;
			newPos.y += playerSpeed * Time.deltaTime * axis;
			newPos.y = Mathf.Clamp (newPos.y, 0f, ScreenInfo.GetInstance ().Height () - rage.GetSizeY ());
			transform.position = newPos;
		}
	}
	
	private void UpdateMouseInput ()
	{
		target = ScreenInfo.GetInstance ().ScreenCoordToGame (Input.mousePosition);
		rage.SetHorizontalFlip (target.x < transform.position.x);
	}
	
	private void UpdateFire ()
	{
		if (Input.GetMouseButtonDown (0) || Input.GetButtonDown ("Fire1")) {
			Fire ();
		}
	}
	
	public void Fire ()
	{
		GameObject b = Instantiate (bullet, transform.position, Quaternion.identity) as GameObject;
		b.SendMessage("SetTarget", target);
	}
	
	public void Reset ()
	{
		gameObject.transform.position = initialPosition;
		rage.SetSprite ("e", 0);
		rage.PlayNamedAnimation ("idle");
	}
	
	public void Die (bool andReset=false)
	{
		StartCoroutine (DoDie (andReset));
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
