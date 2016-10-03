using UnityEngine;
using System.Collections;

public class BackGroundMusicControl : MonoBehaviour {
	
	public AudioSource BackGroundSource;
	public AudioClip background;
	
	// Use this for initialization
	void Start () {
		BackGroundSource = GetComponent<AudioSource> ();
		BackGroundSource.volume = SliderControl.volume;
		BackGroundSource.clip = background;
		BackGroundSource.Play ();
	}
}
