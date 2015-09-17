using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	// Use this for initialization
	public GameObject[] obj;
	public Transform Player;
	public float spawnMin = 1f;
	public float spawnMax = 2f;
	void Start () {
		Spawn ();
	
	}
	
	// Update is called once per frame

	void Spawn()
	{
		Instantiate (obj [Random.Range (0, obj.GetLength(0))], new Vector3(Player.position.x+20,3,0), Quaternion.identity);
		Invoke ("Spawn",Random.Range(spawnMin,spawnMax));
	}
}
