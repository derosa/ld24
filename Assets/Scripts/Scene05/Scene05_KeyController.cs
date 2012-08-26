using UnityEngine;
using System.Collections;

public class Scene05_KeyController : MonoBehaviour {
	private bool alreadyCaptured = false;
	private RagePixelSprite rage;
	
	void Start ()
	{
		rage = GetComponent<RagePixelSprite> ();
	}
	
	public void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Key trigged by " + other.gameObject.name);

		if (other.CompareTag ("Player") && !alreadyCaptured) {
			alreadyCaptured = true;
			StartCapturedTweening ();
			GameObject.FindGameObjectWithTag ("GameController").SendMessage ("KeyGrabbed");
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
	}
}
