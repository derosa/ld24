using UnityEngine;
using System.Collections;

public class DoorSpawner : MonoBehaviour {
	
	public GameObject spawnPoint1;
	public GameObject spawnPoint2;	

	public void SpawnDoors ()
	{
		spawnPoint1.BroadcastMessage ("CanEnter", false);
		spawnPoint2.BroadcastMessage ("CanEnter", false);
	}

}
