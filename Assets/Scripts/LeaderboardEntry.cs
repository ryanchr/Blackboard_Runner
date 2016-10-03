using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeaderboardEntry : MonoBehaviour {
	
	public Text highscoreText1;
	public Text highscoreText2;
	public Text highscoreText3;
	
	public Text user1;
	public Text user2;
	public Text user3;
	
	//public static LeaderboardEntry Instance;
	
	
	// Use this for initialization. The NGUI Labels will update 
	//with the information we pass to them later
	void Start()
	{
		//Instance = this;
		
		UpdateScoreBd ();
	}
	
	
	void OnApplicationQuit() 
	{
		PlayerPrefs.Save();
	}
	
	
	void UpdateScoreBd()
	{
		//Debug.Log ("!LeaderBoardEntry");
		//Debug.Log ("!username1:" + HighScoreContainer.username1);
		//Debug.Log ("!username2:" + HighScoreContainer.username2);
		//Debug.Log ("!username3:" + HighScoreContainer.username3);
		
		if (PlayerPrefs.HasKey ("score1")) {
			highscoreText1.text = ("" + PlayerPrefs.GetInt ("score1"));
			//Debug.Log ("Haskey");
		}
		else {
			PlayerPrefs.SetInt ("score1",1);
			highscoreText1.text = ("" + 1);
		}
		
		if (PlayerPrefs.HasKey ("score2"))
			highscoreText2.text = ("" + PlayerPrefs.GetInt ("score2"));
		else {
			PlayerPrefs.SetInt ("score2",1);
			highscoreText2.text = ("" + 1);
		}
		
		if (PlayerPrefs.HasKey ("score3"))
			highscoreText3.text = ("" + PlayerPrefs.GetInt ("score3"));
		else {
			PlayerPrefs.SetInt ("score3",1);
			highscoreText3.text = ("" + 1);
		}
		
		
		if (PlayerPrefs.HasKey ("user1"))
			user1.text = ("" + PlayerPrefs.GetString ("user1"));
		else {
			PlayerPrefs.SetString("user1","Tom");
			user1.text = ("Tom");
		}
		
		if (PlayerPrefs.HasKey ("user2"))
			user2.text = ("" + PlayerPrefs.GetString ("user2"));
		else {
			PlayerPrefs.SetString ("user2","Jim");
			user2.text = ("Jim");
		}
		
		if (PlayerPrefs.HasKey ("user3"))
			user3.text = ("" + PlayerPrefs.GetString ("user3"));
		else {
			PlayerPrefs.SetString ("user3","Curry");
			user3.text = ("Curry");
		}
		
		PlayerPrefs.Save();
		
		//Debug.Log ("Updated Score Board\n");
		//Debug.Log("highscoreText1.text = " + highscoreText1.text);
		//Debug.Log("highscoreText2.text = " + highscoreText2.text);
		//Debug.Log("highscoreText3.text = " + highscoreText3.text);
		//
		//Debug.Log("user1.text = " + user1.text);
		//Debug.Log("user2.text = " + user2.text);
		//Debug.Log("user3.text = " + user3.text);
		
	}
	
	
}

