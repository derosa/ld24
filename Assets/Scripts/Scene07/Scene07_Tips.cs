using UnityEngine;
using System.Collections;

public class Scene07_Tips : MonoBehaviour {
	public string msg;
	private GameObject text;
	
	void Start ()
	{
		text = GameObject.FindGameObjectWithTag ("tipText");
		text.guiText.enabled = false;
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		
		if (other.CompareTag ("Player")) {
			text.guiText.text = msg;
			text.guiText.enabled = true;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if (other.CompareTag ("Player")) {
			text.guiText.text = "";
			text.guiText.enabled = false;
		}
	}
	
	
	
}
