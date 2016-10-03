using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {

	// Use this for initialization
	public void PlayGame () {
		Application.LoadLevel ("Test");
	}

	public void GotoMenu () {
		Application.LoadLevel ("Menu");
	}

	public void GotoSetting () {
		Application.LoadLevel ("Setting");
	}

	public void GotoLeaderboard () {
		Application.LoadLevel ("Leaderboard");
	}

	public void GotoInstruction () {
		Application.LoadLevel ("Tutorial");
	}

	public void SaveRecords (){
		HighScoreContainer.Instance.UpdateScores ();
		Application.LoadLevel ("Leaderboard");
	}
}
