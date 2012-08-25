using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RagePixelCamera : MonoBehaviour {

	public int pixelSize = 1;
	public int resolutionPixelWidth = 1024;
	public int resolutionPixelHeight = 768;
	public bool snapToIntegerPositions = true;

	public void SnapToIntegerPosition()
	{
		if(snapToIntegerPositions)
		{
			transform.position = new Vector3(Mathf.RoundToInt(transform.position.x) + 0.05f, Mathf.RoundToInt(transform.position.y) - 0.05f, transform.position.z);
		}
	}

	void Awake()
	{

	}

	void Start()
	{
		ResetCamera();
	}

	public void OnPostRender()
	{

	}

	void Update()
	{
		SnapToIntegerPosition();
	}

	public void OnDrawGizmosSelected()
	{
		SnapToIntegerPosition();
	}

	public void ResetCamera ()
	{
		Camera camera = GetComponent (typeof(Camera)) as Camera;
		RagePixelCamera ragePixelCamera = camera.GetComponent<RagePixelCamera>();

		camera.orthographic = true;

		float screenW = ragePixelCamera.resolutionPixelWidth;
		float screenH = ragePixelCamera.resolutionPixelHeight;

		Vector3 position = Vector3.zero;

		position.z = -10.0f;
		position.x = screenW / 2 / ragePixelCamera.pixelSize;
		position.y = screenH / 2 / ragePixelCamera.pixelSize;

		camera.transform.position = position;
		camera.orthographicSize = screenH / 2 / ragePixelCamera.pixelSize;
	}
	
}
