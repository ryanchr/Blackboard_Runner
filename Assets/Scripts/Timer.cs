using UnityEngine;
using System.Collections;
using System;

public class Timer : MonoBehaviour {
//	public UILabel timerLabel;
	private string timerText; 
	private float temp;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		temp += Time.deltaTime;
		TimeSpan timeSpan = TimeSpan.FromSeconds(temp);
		
		timerText = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); 
//		timerLabel.text = timerText;
	
	}

	void OnDisable()
	{
		PlayerPrefs.SetString ("TimeScore", timerText);
	}
}
