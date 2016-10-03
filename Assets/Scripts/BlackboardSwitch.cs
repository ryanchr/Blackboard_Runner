using UnityEngine;
using System.Collections;

public class BlackboardSwitch : MonoBehaviour {
	public Transform Player;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.localPosition.x > transform.localPosition.x + 20) {  
			transform.localPosition = new Vector3(transform.localPosition.x + 300, transform.localPosition.y, transform.localPosition.z);  
		} 

		if (Player.localPosition.y > transform.localPosition.y + 25) {  
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 54, transform.localPosition.z);  
		} 
		if (Player.localPosition.y < transform.localPosition.y - 25) {  
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 54, transform.localPosition.z);  
		} 
	}
}
