using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Debug.Break ();
			return;
		}

		if (other.tag == "paint")
		{
			Destroy(other.gameObject);
			return;
		}

		if (other.tag == "box") {
			Destroy(other.gameObject);
			return;
		}

		if (other.gameObject.transform.parent.gameObject) {
			Destroy (other.gameObject.transform.parent.gameObject);
		} 
		else {
			Destroy(other.gameObject);
		}
	}

}
