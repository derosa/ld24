using UnityEngine;
using System.Collections;

public class AnimableObject : MonoBehaviour {

	public void AnimateAndDestroy (GameObject rage, string animationName)
	{
		StartCoroutine (DoAnimateAndDestroy (rage, animationName));
	}
	
	IEnumerator DoAnimateAndDestroy (GameObject _rage, string animationName)
	{
		IRagePixel rage = _rage.GetComponent<RagePixelSprite> ();
			
		rage.StopAnimation ();
		rage.PlayNamedAnimation (animationName);
		while (rage.isPlaying()) {
			yield return new WaitForSeconds(0.1f);
		}
		
		Destroy (_rage);
		yield return 0;
	}
}
