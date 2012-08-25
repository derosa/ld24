using UnityEngine;
using System.Collections;

public class NextButton : MonoBehaviour {

	public int sceneToLoad = 0;
	
	public void OnMouseDown(){
		Application.LoadLevel(sceneToLoad);
	}
}
