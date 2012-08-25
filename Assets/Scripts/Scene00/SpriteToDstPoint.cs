using UnityEngine;
using System.Collections;

public class SpriteToDstPoint : MonoBehaviour {
	public GameObject dstPoint;
	private bool inPlace = false;
	private Vector3 initialPosition;
	
	void Start ()
	{
		inPlace = false;
		initialPosition = transform.position;
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == dstPoint) {
			transform.rigidbody.velocity = Vector3.zero;
			inPlace = true;
			Debug.Log (gameObject.name + " in position");
		}
	}
	
	public bool IsInPlace ()
	{
		return inPlace;
	}
	
	public void Reset ()
	{
		inPlace = false;
		transform.position = initialPosition;
		transform.rigidbody.velocity = Vector3.zero;
	}
	
	
}
