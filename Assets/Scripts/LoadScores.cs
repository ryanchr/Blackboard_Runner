using UnityEngine;
using System.Collections;

public class LoadScores : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		LoadSaveData ();
		//PlayerPrefs.DeleteAll ();
	}
	
	// Update is called once per frame
	void Update () {
		//LoadSaveData ();
	}
	
	
	void OnDisable(){
		//PlayerPrefs.Save();	
	}
	
	void OnApplicationQuit() 
	{
		PlayerPrefs.Save();
	}
	
	
	void LoadSaveData()
	{
		
		if (PlayerPrefs.HasKey ("score1")) {
			HighScoreContainer.highscore1 = PlayerPrefs.GetInt ("score1");
			//Debug.Log ("Haskey");
		}
		else {
			PlayerPrefs.SetInt ("score1",1);
			HighScoreContainer.highscore1 = 1;
		}
		
		if (PlayerPrefs.HasKey ("score2"))
			HighScoreContainer.highscore2 = PlayerPrefs.GetInt ("score2");
		else {
			PlayerPrefs.SetInt ("score2",1);
			HighScoreContainer.highscore2 = 1;
		}
		
		if (PlayerPrefs.HasKey ("score3"))
			HighScoreContainer.highscore3 = PlayerPrefs.GetInt ("score3");
		else {
			PlayerPrefs.SetInt ("score3",1);
			HighScoreContainer.highscore3 = 1;
		}
		
		
		if (PlayerPrefs.HasKey ("user1")) {
			HighScoreContainer.username1 = PlayerPrefs.GetString ("user1");
			if (HighScoreContainer.username1 == ""){
				HighScoreContainer.username1 = "Anonymous";
				PlayerPrefs.SetString ("user1","Anonymous");
			}
			//Debug.Log ("Has String\n");
		}
		else {
			PlayerPrefs.SetString("user1","Tom");
			HighScoreContainer.username1 = "Tom";
		}
		
		if (PlayerPrefs.HasKey ("user2")){
			HighScoreContainer.username2 = PlayerPrefs.GetString ("user2");
			if (HighScoreContainer.username2 == "") {
				HighScoreContainer.username2 = "Anonymous";
				PlayerPrefs.SetString ("user2", "Anonymous");
			}
		}
		else {
			PlayerPrefs.SetString("user2","Jim");
			HighScoreContainer.username2 = "Jim";
		}
		
		if (PlayerPrefs.HasKey ("user3")) {
			HighScoreContainer.username3 = PlayerPrefs.GetString ("user3");
			if (HighScoreContainer.username3 == "") {
				HighScoreContainer.username3 = "Anonymous";
				PlayerPrefs.SetString ("user3", "Anonymous");
			}
		}
		else {
			PlayerPrefs.SetString ("user3","Curry");
			HighScoreContainer.username3 = "Curry";
		}
		
		
		PlayerPrefs.Save();
		//Debug.Log ("Load Score\n");
		//Debug.Log("HighScoreContainer.highscore1 = " + HighScoreContainer.highscore1);
		//
		//Debug.Log("HighScoreContainer.username1" + HighScoreContainer.username1);
		
		
	}
}
