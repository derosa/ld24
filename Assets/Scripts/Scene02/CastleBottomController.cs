using UnityEngine;
using System.Collections;

public class CastleBottomController : MonoBehaviour {
	
	public GameObject castleTop;
	
	private int nClicksToBreak = 4;
	
	public void OnMouseDown ()
	{
		Debug.Log ("Click");
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
		for (int t=0; t < transform.childCount; t++) {
			GameObject o = transform.GetChild (t).gameObject;
			r = o.GetComponent<RagePixelSprite> ();
			r.SetSprite ("explosion", 0);
			r.PlayNamedAnimation ("explode");
		}
			
		Debug.Log ("BOOM");
		castleTop.SendMessage ("Fall");
		StartCoroutine(WaitForAnimationAndDestroy(r));
		//Destroy (gameObject);
	}
	
	private void ChangeSprite (int damage)
	{
		for (int t=0; t < transform.childCount; t++) {
			GameObject o = transform.GetChild (t).gameObject;
			RagePixelSprite rage = o.GetComponent<RagePixelSprite> ();
			rage.SetSprite ("castle_base", damage);
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
