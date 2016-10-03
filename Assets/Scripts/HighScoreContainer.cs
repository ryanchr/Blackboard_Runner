using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreContainer : MonoBehaviour {
	public static string username1;
	public static string username2;
	public static string username3;
	
	static public int highscore1;
	static public int highscore2;
	static public int highscore3;
	
	public InputField iField;
	public static string myname;
	
	public static HighScoreContainer Instance;
	
	// Use this for initialization
	void Start () {
		//LoadSaveData ();
		Instance = this;
		//iField.;
	}
	
	// Update is called once per frame
	void Update () {
		
		myname = iField.text;  
		//Recordscore ();
		
	}
	
	
	void OnApplicationQuit() 
	{
		PlayerPrefs.Save();
	}
	
	
	public void UpdateScores()
	{
		
		//Debug.Log ("~Myname:" + myname);
		//Debug.Log ("!username1:" + username1);
		//Debug.Log ("!username2:" + username2);
		//Debug.Log ("!username3:" + username3);
		
		
		
		if (ScoreLabel.score > highscore1) {
			highscore3 = highscore2;
			username3 = username2;
			
			highscore2 = highscore1;
			username2 = username1;
			
			highscore1 = ScoreLabel.score;
			username1 = myname;
			
			PlayerPrefs.SetInt ("score1", highscore1);
			PlayerPrefs.SetInt ("score2", highscore2);
			PlayerPrefs.SetInt ("score3", highscore3);
			
			PlayerPrefs.SetString ("user1", username1);
			PlayerPrefs.SetString ("user2", username2);
			PlayerPrefs.SetString ("user3", username3);
			
			Debug.Log ("!>highscore1:" + myname);
			Debug.Log ("!username1:" + username1);
			Debug.Log ("!username2:" + username2);
			Debug.Log ("!username3:" + username3);
			
		} else if (ScoreLabel.score > highscore2) {
			highscore3 = highscore2;
			username3 = username2;
			
			highscore2 = ScoreLabel.score;
			username2 = myname;
			
			PlayerPrefs.SetInt ("score2", highscore2);
			PlayerPrefs.SetInt ("score3", highscore3);
			
			PlayerPrefs.SetString ("user2", username2);
			PlayerPrefs.SetString ("user3", username3);
			
			Debug.Log ("!>highscore2:" + myname);
			Debug.Log ("!username1:" + username1);
			Debug.Log ("!username2:" + username2);
			Debug.Log ("!username3:" + username3);
			
		} else if (ScoreLabel.score > HighScoreContainer.highscore3) {
			highscore3 = ScoreLabel.score;
			username3 = myname;
			
			PlayerPrefs.SetInt ("score3", highscore3);
			PlayerPrefs.SetString ("user3", username3);
			
			
			Debug.Log ("!>highscore3:" + myname);
			Debug.Log ("!username1:" + username1);
			Debug.Log ("!username2:" + username2);
			Debug.Log ("!username3:" + username3);
		}
		
		
		
		
		PlayerPrefs.Save ();
	}
	
}
