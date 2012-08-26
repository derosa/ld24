using UnityEngine;
using System.Collections;

public class Scene09_CatSpawner : MonoBehaviour {
	
	public GameObject cat;
	public float spawnRate = 10.0f;
	
	private float nextSpawnTime = 0f;
	private bool _doSpawn = false;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	public void DoSpawn(bool d){
		_doSpawn = d;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!_doSpawn) {
			return;
		}
		
		if (Time.time > nextSpawnTime) {
			nextSpawnTime = Time.time + 1f / spawnRate;
			SpawnCat ();
		}	
	}
	
	private void SpawnCat ()
	{
		Vector3 newPos = RandomPointOffScreen();
		Instantiate (cat, newPos, Quaternion.identity);
	}
	
	private Vector3 RandomPointOffScreen (bool fromRight = true)
	{
		float width = ScreenInfo.GetInstance ().Width ();
		float height = ScreenInfo.GetInstance ().Height ();

		float angle = Random.Range (0f, 360f);
		//float newX = Mathf.Cos (angle * Mathf.Deg2Rad);
		float newY = Mathf.Sin (angle * Mathf.Deg2Rad);
		
		Vector3 newPos = Vector3.zero;
		//newPos.x = newX;
		if (fromRight) {
			newPos.x = width + cat.GetComponent<RagePixelSprite> ().GetSizeX ();
		} else {
			newPos.x = -cat.GetComponent<RagePixelSprite> ().GetSizeX ();
		}
		
		newPos.y = Mathf.Abs (newY) * height;
		newPos.z = 0.0f;
		//newPos *= Mathf.Max (width, height) * 2f;
		
		
		return newPos;
		
	}
	
	public void SetCatSpawnRate (int n)
	{
		Debug.Log ("New Spawn rate: " + n);
		spawnRate = (float)n;
	}
	
}
