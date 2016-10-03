using UnityEngine;
using System.Collections;

public class backgound_spawn : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D  coll){
		if (coll.name == "Destroyer") {
			GameObject.Find("GameSpawn").GetComponent<SpawnScript>().spawn_bg();
		}
	}
	
}
