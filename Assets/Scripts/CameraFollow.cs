using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
	public Transform Player;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Player.position.x+5, Player.position.y, -10);
	}
}
