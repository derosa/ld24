using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
[RequireComponent (typeof(Rigidbody))]

public class LetterController : MonoBehaviour {
	private bool alreadyCaptured = false;
	private string spriteName;
	private RagePixelSprite rage;
	private int spriteRow;
	
	void Start ()
	{
		rage = GetComponent<RagePixelSprite> ();
		spriteName = rage.name;
		spriteRow = rage.GetCurrentRowIndex();
	}
	
	public void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player")) {
			if (!alreadyCaptured) {
				alreadyCaptured = true;
				Debug.Log ("Letra capturada!");
				rage.SetSprite ("explosions");
				rage.PlayAnimation();
			}
		}
	}
	
	public void Reset ()
	{
		alreadyCaptured = false;
		rage.SetSprite (spriteName);
		rage.selectRow(spriteRow);
	}
}
