using UnityEngine;
using System.Collections;

public class gameovermusic : MonoBehaviour {
	
	public AudioSource gameovermusicfile;
	public AudioClip ggbackground;

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

	public int texturedimension;
	public int locationx;
	public int locationy;
	public string myStringScore;

	// Use this for initialization
	void Start () {
		gameovermusicfile = GetComponent<AudioSource> ();
		gameovermusicfile.volume = SliderControl.volume;
		gameovermusicfile.clip = ggbackground;
		gameovermusicfile.Play ();

		texturedimension = 75;
		locationx = 510;
		locationy = 360;
		myStringScore = ScoreLabel.score.ToString();
	}

	void OnGUI()
	{
		//GUI.Label(new Rect(Screen.width / 2 - 40, 300, 100, 30), "Time: "+TimeScore);
		for (int i =0; i < myStringScore.Length; i++) {
			//GUI.DrawTexture (new Rect (0, 0, 200, 200), one);
			switch (myStringScore [i]) {
			case '0':
				GUI.DrawTexture (new Rect (i * texturedimension + locationx, locationy, texturedimension, texturedimension), zero);
				break;
			case '9':
				GUI.DrawTexture (new Rect (i * texturedimension + locationx, locationy, texturedimension, texturedimension), nine);
				break;
			case '8':
				GUI.DrawTexture (new Rect (i * texturedimension + locationx, locationy, texturedimension, texturedimension), eight);
				break;
			case '7':
				GUI.DrawTexture (new Rect (i * texturedimension + locationx, locationy, texturedimension, texturedimension), seven);
				break;
			case '6':
				GUI.DrawTexture (new Rect (i * texturedimension + locationx, locationy, texturedimension, texturedimension), six);
				break;
			case '5':
				GUI.DrawTexture (new Rect (i * texturedimension + locationx, locationy, texturedimension, texturedimension), five);
				break;
			case '4':
				GUI.DrawTexture (new Rect (i * texturedimension + locationx, locationy, texturedimension, texturedimension), four);
				break;
			case '3':
				GUI.DrawTexture (new Rect (i * texturedimension + locationx, locationy, texturedimension, texturedimension), three);
				break;
			case '2':
				GUI.DrawTexture (new Rect (i * texturedimension + locationx, locationy, texturedimension, texturedimension), two);
				break;
			case '1':
				GUI.DrawTexture (new Rect (i * texturedimension + locationx, locationy, texturedimension, texturedimension), one);
				break;
			}
		}
	}
			
		
}
