using UnityEngine;
using System.Collections;

public class ExplodeButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	
	}
	
	void OnMouseDown ()
	{
		float delay = 0.0f;
		
		foreach (GameObject o in GameObject.FindGameObjectsWithTag("explosive")) {
			StartCoroutine (WaitAndExplode (o, delay));
			delay += 0.2f;
		}
	}
	IEnumerator WaitAndExplode (GameObject o, float delay)
	{
		yield return new WaitForSeconds(delay);
		Vector3 explodePosition = o.transform.position;
		o.SendMessage ("Explode", SendMessageOptions.RequireReceiver);	
		while (o != null) {
			yield return new WaitForSeconds(0.1f);
		}
		Collider[] colliders = Physics.OverlapSphere (explodePosition, 20);
		foreach (Collider c in colliders) {
			//Debug.Log ("Collider: " + c.name);
			if (c.rigidbody) {
				c.rigidbody.AddExplosionForce (1000, explodePosition, 20);
			}
		}
	}
}
