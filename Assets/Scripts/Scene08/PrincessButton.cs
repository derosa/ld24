using UnityEngine;
using System.Collections;

public class PrincessButton : MonoBehaviour {
	public GameObject princess;
	private GameObject _p;
	private bool needRefresh = false;
	
	void OnMouseDown ()
	{
		Debug.Log ("Click");
		_p = Instantiate (princess, ScreenInfo.GetInstance ().Center () + Vector3.down * 30.0f, 
			Quaternion.identity) as GameObject;

		needRefresh = true;
	}
	
	void LateUpdate ()
	{
		if (_p != null && needRefresh) {
			_p.SendMessage ("Restart");
			IRagePixel rage = _p.GetComponent<RagePixelSprite> ();
			_p.SendMessage ("Fall");
			rage.PlayNamedAnimation ("panic");
			needRefresh = false;
		}
	}
}
