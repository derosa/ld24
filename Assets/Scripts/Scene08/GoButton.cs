using UnityEngine;
using System.Collections;

public class GoButton : MonoBehaviour {
	public int nextLevel = 0;
	
	void OnMouseDown ()
	{
		Application.LoadLevel (nextLevel);
		
	}
	
}
