<<<<<<< HEAD
﻿using UnityEngine;
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
=======
﻿using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {
	public Transform[] Blackboards;
	public Transform[] Backgrounds;
	private float[] parallaxScales;
	public float smoothing = 1f;

	private Transform cam;
	private int curNum = 0;

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
		//switch blackboards
		if (cam.position.x > Blackboards[curNum].localPosition.x) {
			if (curNum == Blackboards.Length - 1) {
				curNum = 0;
			} else {
				curNum += 1;
			}
			Blackboards [curNum].localPosition = new Vector3 (cam.position.x+139, Blackboards [curNum].localPosition.y, Blackboards [curNum].localPosition.z);	
		}

		for (int i = 0; i < Backgrounds.Length; i++) {
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
			float backgroundTargetPosX = Backgrounds[i].position.x + parallax;
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, Backgrounds[i].position.y, Backgrounds[i].position.z);
			Backgrounds[i].position = Vector3.Lerp(Backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
			/*
			if (cam.position.x > Backgrounds[i].localPosition.x+25) {
				Backgrounds[i].localPosition = new Vector3 (cam.position.x+50, Backgrounds[i].localPosition.y, Backgrounds[i].localPosition.z);	
			}*/
		}
		previousCamPos = cam.position;
	}
}
>>>>>>> origin/master
