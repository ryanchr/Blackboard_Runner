using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SliderControl : MonoBehaviour {
	
	public static float volume = 0.5f;
	public UnityEngine.UI.Slider SoundSlider;
	// Use this for initialization
	void Start () {
		SoundSlider = GameObject.Find ("sound").GetComponent<Slider>();
		SoundSlider.value = volume;
	}
	
	// Update is called once per frame
	void Update () {
		volume = SoundSlider.value;
	}
}
