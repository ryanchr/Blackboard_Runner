using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {
	public Transform[] Backgrounds;
	private float[] parallaxScales;
	public float smoothing = 1f;
	private Transform cam;
	private Vector3 previousCamPos;

	void Awake() {
		cam = Camera.main.transform;
	}

	void Start () {
		previousCamPos = cam.position;
		parallaxScales = new float[Backgrounds.Length];
		for (int i = 0; i < Backgrounds.Length; i++) {
			parallaxScales[i] = Backgrounds[i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Backgrounds.Length; i++) {
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
			float backgroundTargetPosX = Backgrounds[i].position.x + parallax;
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, Backgrounds[i].position.y, Backgrounds[i].position.z);
			Backgrounds[i].position = Vector3.Lerp(Backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}
		previousCamPos = cam.position;
	}
}
