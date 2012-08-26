using UnityEngine;
using System.Collections;

public class Scene06_LightController : MonoBehaviour {
	
	public GameObject player;
	
	void Update ()
	{
		if (true) {
			Vector3 newPos = ScreenInfo.GetInstance ().ScreenCoordToGame (Input.mousePosition);
			
			newPos.z = player.transform.position.z;
			player.transform.position = newPos;
			
			newPos.z = transform.position.z;
			transform.position = newPos;
			
		}
	}
}
