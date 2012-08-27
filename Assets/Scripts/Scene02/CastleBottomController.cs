using UnityEngine;
using System.Collections;

public class CastleBottomController : MonoBehaviour {
	
	public GameObject castleTop;
	public GameObject damageLayer;
	public int clicksToBreak = 5;
	private int nClicksToBreak = 5;
	
	void Start ()
	{
		nClicksToBreak = clicksToBreak;
	}
	
	public void OnMouseDown ()
	{
		Debug.Log ("Click");
		audio.Play();
		nClicksToBreak--;
		if (nClicksToBreak < 0) {
			ExplodeAndDestroy ();
		} else {
			ChangeSprite (nClicksToBreak);
		}
		
	}
	
	private void ExplodeAndDestroy ()
	{
		RagePixelSprite r = null;
		damageLayer.active=false;
		for (int t=0; t < transform.childCount; t++) {
			GameObject o = transform.GetChild (t).gameObject;
			r = o.GetComponent<RagePixelSprite> ();
			if (r != null) {
				r.SetSprite ("explosion", 0);
				r.PlayNamedAnimation ("explode");
			}
		}
			
		Debug.Log ("BOOM");
		castleTop.SendMessage ("Fall");
		StartCoroutine (WaitForAnimationAndDestroy (r));
		//Destroy (gameObject);
	}
	
	private void ChangeSprite (int damage)
	{
		int level = clicksToBreak - nClicksToBreak;
		for (int t=0; t < transform.childCount; t++) {
			GameObject o = transform.GetChild (t).gameObject;
			RagePixelSprite rage = damageLayer.GetComponent<RagePixelSprite> ();
			rage.SetSprite ("castleDamage", level);
		}
	}
	
	private IEnumerator WaitForAnimationAndDestroy (RagePixelSprite r)
	{
		while (r.isPlaying()) {
			yield return new WaitForSeconds(0.1f);
		}
		Destroy (gameObject);
	}
}
