using UnityEngine;
using System.Collections;

public class PrincessController : MonoBehaviour {
	private GameObject hair;
	private int maxHairDeploy = 2;
	private int hairDeployed = 0;
	private bool hairVisible = false;
	private int origHairWidth;
	private IRagePixel hairRage;
	private IRagePixel rage;
	
	public void Start ()
	{
		rage = GetComponent<RagePixelSprite> ();
		rage.PlayNamedAnimation("idle");
		hair = transform.GetChild (0).gameObject;
		hairRage = hair.GetComponent<RagePixelSprite> ();
		hair.active = false;
		
	}
	
	public void OnMouseDown ()
	{
		Debug.Log ("Pelo");
		
		if (hairDeployed == maxHairDeploy) {
			return;
		}
		hairDeployed++;
		if (!hairVisible) {
			hairVisible = true;
			hair.active = true;
			origHairWidth = hairRage.GetSizeX ();
		} else {
			int newX = origHairWidth * hairDeployed;
			int newY = hairRage.GetSizeY ();
			hairRage.SetSize (newX, newY);
			hair.transform.Translate (0f, -newY, 0f);
		}
	}
	
	public void Fall ()
	{
		rage.StopAnimation ();
		rage.SetSprite ("lady_ld", 2);
		iTween.ScaleTo (gameObject, iTween.Hash ("scale", Vector3.one * 10f, 
			"delay", 0.25f, 
			"time", 0.5f, 
			"easetype", iTween.EaseType.easeInOutBounce,
			"oncomplete", "SlideDown"));
		
		/*iTween.RotateBy(gameObject, iTween.Hash ("amount", Vector3.back * 1.1f, 
			"delay", 0.25f, 
			"time", 0.5f, 
			"easetype", iTween.EaseType.easeInOutCubic));*/
	}
	
	private void SlideDown ()
	{
		iTween.MoveTo (gameObject, iTween.Hash ("position", transform.position + Vector3.down * rage.GetSizeY () * transform.localScale.y, 
			"time", 1.5f,
			"easetype", iTween.EaseType.easeInExpo,
			"oncomplete", "DestroyPrincess"));
	}
	
	private void DestroyPrincess(){
		Destroy(gameObject);
	}
}
