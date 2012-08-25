using UnityEngine;
using System.Collections;

public class CastleBottomController : MonoBehaviour {
	
	public GameObject castleTop;
	
	private int nClicksToBreak = 10;
	
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
		Debug.Log ("BOOM");
		Destroy (gameObject);
	}
	
	private void ChangeSprite (int damage)
	{
		for (int t=0; t < transform.childCount; t++) {
			GameObject o = transform.GetChild(t).gameObject;
			RagePixelSprite rage = o.GetComponent<RagePixelSprite>();
			rage.SetSprite("castle_base", 1);
		}
	}
}
