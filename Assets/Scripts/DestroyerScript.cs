using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Debug.Break ();
		}

		if (other.gameObject.transform.parent.gameObject) {
			Destroy (other.gameObject.transform.parent.gameObject);
		} 
		else {
			Destroy(other.gameObject);
		}
	}

}
