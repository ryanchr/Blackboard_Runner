using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
	public Transform Player;
	private bool isFlip = false;
	/*void Start()
	{
		Matrix4x4 mat = Camera.main.projectionMatrix;
		mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
		Camera.main.projectionMatrix = mat;
	}*/
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Player.position.x+5, Player.position.y, -10);
	}

	public void flip()
	{
		if (!isFlip) {
			Matrix4x4 mat = Camera.main.projectionMatrix;
			mat *= Matrix4x4.Scale (new Vector3 (-1, 1, 1));
			Camera.main.projectionMatrix = mat;
			isFlip = true;
		}
	}

	public void reflip()
	{
		Matrix4x4 mat = Camera.main.projectionMatrix;
		mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
		Camera.main.projectionMatrix = mat;
		isFlip = false;
	}

}
