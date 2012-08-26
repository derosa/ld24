using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
[RequireComponent (typeof(Rigidbody))]

public class LetterController : MonoBehaviour {
	private bool alreadyCaptured = false;
	private Vector3 originalSize;
	private RagePixelSprite rage;
	
	void Start ()
	{
		rage = GetComponent<RagePixelSprite> ();
		rage.SetTintColor (ColorUtils.RandomColor ());
		originalSize = transform.localScale;
	}
	
	public void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player")) {
			if (!alreadyCaptured) {
				alreadyCaptured = true;
				Debug.Log ("Letra capturada!");
				StartCapturedTweening ();
				GameObject.FindGameObjectWithTag ("GameController").SendMessage ("LetterCaptured");
			}
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
		rage.SetTintColor(tint);
	}
	
	public void Reset ()
	{
		iTween.Stop ();
		alreadyCaptured = false;
		rage.SetTintColor (ColorUtils.RandomColor ());
		transform.localScale = originalSize;
	}
}
