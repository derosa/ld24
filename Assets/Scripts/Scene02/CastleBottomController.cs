using UnityEngine;
using System.Collections;

public class CastleBottomController : MonoBehaviour {
	
	public GameObject castleTop;
	
	private int nClicksToBreak = 10;
	
	public void OnMouseDown ()
	{
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
	
	private void ChangeSprite(int damage){
		Debug.Log ("Cambiar el sprite");
	}
}
