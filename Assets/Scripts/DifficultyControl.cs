using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class DifficultyControl : MonoBehaviour {
	
	public static float difficulty = 0.5f;
	public UnityEngine.UI.Slider DifficultySlider;
	// Use this for initialization
	void Start () {
		DifficultySlider = GameObject.Find ("difficulty").GetComponent<Slider>();
		DifficultySlider.value = difficulty;
	}
	
	// Update is called once per frame
	void Update () {
		difficulty = DifficultySlider.value;
	}
}
