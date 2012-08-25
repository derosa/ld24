using UnityEngine;
using System.Collections;

public class CastleTopController : MonoBehaviour {
	public GameObject princess;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public void Fall ()
	{
		Vector3 newPosition = gameObject.transform.position;
		newPosition.y = 16.0f;
		
		iTween.MoveTo (gameObject, iTween.Hash ("position", newPosition, 
			"delay", 0.25f, 
			"time", 0.5f, 
			"easetype", iTween.EaseType.easeOutBounce));
			
		princess.SendMessage("Fall");
	}
	
}
