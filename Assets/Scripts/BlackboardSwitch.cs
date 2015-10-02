using UnityEngine;
using System.Collections;

public class BlackboardSwitch : MonoBehaviour {
	public Transform Player;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.localPosition.x > transform.localPosition.x - 20) {  
			transform.localPosition = new Vector3(transform.localPosition.x + 120, transform.localPosition.y,transform.localPosition.z);  
		} 
	}
}
