using UnityEngine;
using System.Collections;

public class Scene07_LetterController : MonoBehaviour {
	
	private RagePixelSprite rage;
	private bool _alreadyCaptured = false;
	
	// Use this for initialization
	void Start ()
	{
		rage = GetComponent<RagePixelSprite> ();
		rage.SetTintColor(ColorUtils.RandomColor());
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (gameObject.active && _alreadyCaptured) {
			Vector3 newPos = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 10f));
			transform.position = newPos;
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player") && !_alreadyCaptured) {
			GameObject.FindGameObjectWithTag ("GameController").SendMessage ("LetterGrabbed");
			audio.Play ();
			// Lets reposition in front of the player, so the fade looks nice.
			_alreadyCaptured = true;
			StartCapturedTweening ();
			
		}
	}
	
	private void StartCapturedTweening ()
	{
		iTween.ValueTo (gameObject, iTween.Hash ("name", "alpha", 
			"from", 1.0f, 
			"to", 0.0f, 
			"time", 0.5f, 
			"onupdate", "UpdateAlpha"));
		
		Vector3 scale = Vector3.zero;
		scale.x = 5f;
		scale.y = 5f;

		iTween.ScaleTo (gameObject, scale, 0.25f);
			
	}

	private void UpdateAlpha (float a)
	{
		Color tint = rage.tintColor;
		tint.a = a;
		rage.SetTintColor (tint);
		
		if (a == 0.0f) {
			gameObject.active=false;
		}
	}
	
}
