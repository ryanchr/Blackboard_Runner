using UnityEngine;
using System.Collections;

public class Paint : MonoBehaviour {
	private bool PosUp = true;
	private float time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time < 0.5f) {
			if (PosUp) {
				gameObject.transform.position += new Vector3 (0, 0.01f, 0);
			} else {
				gameObject.transform.position += new Vector3 (0, -0.01f, 0);
			}
		} else {
			time = 0f;
			PosUp = !PosUp;
		}
	}
}
