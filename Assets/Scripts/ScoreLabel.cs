using UnityEngine;
using System.Collections;
using System;

public class ScoreLabel : MonoBehaviour {
	public static int score;

	public Texture2D one;
	public Texture2D two;
	public Texture2D three;
	public Texture2D four;
	public Texture2D five;
	public Texture2D six;
	public Texture2D seven;
	public Texture2D eight;
	public Texture2D nine;
	public Texture2D zero;

	private float temp;

	public int texturedimension;
	public int locationx;
	public int locationy;
	private string scoreText; 
	// Use this for initialization
	void Start () {
		temp = 0;
		texturedimension = 60;
		locationx = 800;
		locationy = 40;
	}
	
	// Update is called once per frame
	void Update () {
		temp += Time.deltaTime;
		TimeSpan timeSpan = TimeSpan.FromSeconds(temp);
		score = timeSpan.Hours*3600+timeSpan.Minutes*60+timeSpan.Seconds;  // based on time
		score = score + PlayerController.Eaten_chalk_or_box_number * 3;
		score = score * Mathf.FloorToInt(Mathf.Pow(5, DifficultyControl.difficulty));
		scoreText = score.ToString(); 
		
	}
	
	void OnDisable()
	{
		temp = 0;
	}
	
	void OnGUI()
	{
		for (int i =0; i < scoreText.Length; i++){
			//GUI.DrawTexture (new Rect (0, 0, 200, 200), one);
			switch (scoreText[i])
			{
			case '0':
				GUI.DrawTexture (new Rect (i * texturedimension+locationx, locationy, texturedimension, texturedimension), zero);
				break;
			case '9':
				GUI.DrawTexture (new Rect (i * texturedimension+locationx, locationy, texturedimension, texturedimension), nine);
				break;
			case '8':
				GUI.DrawTexture (new Rect (i * texturedimension+locationx, locationy, texturedimension, texturedimension), eight);
				break;
			case '7':
				GUI.DrawTexture (new Rect (i * texturedimension+locationx, locationy, texturedimension, texturedimension), seven);
				break;
			case '6':
				GUI.DrawTexture (new Rect (i * texturedimension+locationx, locationy, texturedimension, texturedimension), six);
				break;
			case '5':
				GUI.DrawTexture (new Rect (i * texturedimension+locationx, locationy, texturedimension, texturedimension), five);
				break;
			case '4':
				GUI.DrawTexture (new Rect (i * texturedimension+locationx, locationy, texturedimension, texturedimension), four);
				break;
			case '3':
				GUI.DrawTexture (new Rect (i * texturedimension+locationx, locationy, texturedimension, texturedimension), three);
				break;
			case '2':
				GUI.DrawTexture (new Rect (i * texturedimension+locationx, locationy, texturedimension, texturedimension), two);
				break;
			case '1':
				GUI.DrawTexture (new Rect (i * texturedimension+locationx, locationy, texturedimension, texturedimension), one);
				break;
			}
			
		}
	}
}

