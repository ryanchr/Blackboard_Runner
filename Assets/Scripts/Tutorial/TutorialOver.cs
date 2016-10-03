using UnityEngine;
using System.Collections;

public class TutorialOver : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col){
		Application.LoadLevel ("Menu");
	}
}
