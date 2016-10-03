using UnityEngine;
using System.Collections;

public class showTriangle : MonoBehaviour {
	
	public AudioClip audio_triangle;
	private AudioSource source;
	
	private float xstart;
	private float ystart;
	private float xchange_p;
	private float ychange_p;
	private float xchange_n;
	private float ychange_n;
	private float xchange_p_d;
	private float xchange_n_d;
	private float val;

	public GameObject drawTriangle;
	public GameObject attention;
	private GameObject temp;
	private bool comeIn = false;
	private bool isFilled = false;

	void Start () {
		//GameObject.Find("line").SetActive(false);
		source = GetComponent<AudioSource> ();
		transform.parent.Find ("triangle").gameObject.SetActive (false);
		val = 80;
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(!comeIn){
			if (coll.tag == "Player") {
				Vector3 DrawExclamation = new Vector3(transform.parent.Find ("Obstacle_sheep").position.x, transform.parent.Find ("Obstacle_sheep").position.y+2.0f, transform.parent.Find ("Obstacle_sheep").position.z);
				temp = Instantiate (attention, DrawExclamation, Quaternion.identity) as GameObject;
				comeIn = true;
			}
		}
		if (coll.tag == "Player" && GameObject.Find ("Player").GetComponent<PlayerController> ().isHelpfilled) 
		{
			isFilled = true;
			transform.parent.Find ("triangle").gameObject.SetActive (true);
			source.PlayOneShot(audio_triangle, SliderControl.volume);
			Vector3 DrawTrianglePos = new Vector3(transform.parent.Find ("triangle").position.x - 0.5f, transform.parent.Find ("triangle").position.y + 0.5f, transform.parent.Find ("triangle").position.z);
			Instantiate(drawTriangle,DrawTrianglePos,transform.parent.Find ("triangle").rotation);
			if(temp!=null)
			{
				Destroy(temp);
			}
		}
		#if UNITY_EDITOR
		if (Input.GetKey(KeyCode.Space)&&coll.tag == "Player") {
			transform.parent.Find ("triangle").gameObject.SetActive (true);
			source.PlayOneShot(audio_triangle, SliderControl.volume);
			Vector3 DrawTrianglePos = new Vector3(transform.parent.Find ("triangle").position.x - 0.5f, transform.parent.Find ("triangle").position.y + 0.5f, transform.parent.Find ("triangle").position.z);
			Instantiate(drawTriangle,DrawTrianglePos,transform.parent.Find ("triangle").rotation);
			if(temp!=null)
						Destroy(temp);
		}
		#endif
		if (Input.touchCount > 0 && coll.tag == "Player") {
			var touch = Input.GetTouch (0);
			switch (touch.phase) {
			case TouchPhase.Began:
				xstart = touch.position.x;
				ystart = touch.position.y;
				xchange_p = 0;
				ychange_p = 0;
				xchange_n = 0;
				ychange_n = 0;
				xchange_p_d = 0;
				xchange_n_d = 0;
				break;
			case TouchPhase.Moved:
				if (touch.position.x > xstart){
					if(xchange_p < Mathf.Abs (xstart - touch.position.x))
						xchange_p = Mathf.Abs (xstart - touch.position.x);	
					xchange_p_d = xchange_p_d+Mathf.Abs (xstart - touch.position.x);
				}
				if (touch.position.x < xstart){
					if(xchange_n < Mathf.Abs (xstart - touch.position.x))
						xchange_n = Mathf.Abs (xstart - touch.position.x);	
					xchange_n_d = xchange_n_d+Mathf.Abs (xstart - touch.position.x);
				}
				if (touch.position.y > ystart && ychange_p < Mathf.Abs (ystart - touch.position.y))
					ychange_p = Mathf.Abs (ystart - touch.position.y);	
				if (touch.position.y < ystart && ychange_n < Mathf.Abs (ystart - touch.position.y))
					ychange_n = Mathf.Abs (ystart - touch.position.y);
				break;
			case TouchPhase.Ended:
				if (xchange_n > val && ychange_n > val)
				{
					transform.parent.Find ("triangle").gameObject.SetActive (true);
					source.PlayOneShot(audio_triangle, SliderControl.volume);
					Vector3 DrawTrianglePos = new Vector3(transform.parent.Find ("triangle").position.x - 0.5f, transform.parent.Find ("triangle").position.y + 0.5f, transform.parent.Find ("triangle").position.z);
					Instantiate(drawTriangle,DrawTrianglePos,transform.parent.Find ("triangle").rotation);
					if(temp!=null)
						Destroy(temp);
				}
				break;
				
			}
		}
		
	}
	
	void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.tag == "Player" && GameObject.Find ("Player").GetComponent<PlayerController> ().isHelpfilled&&!isFilled) 
		{
			isFilled = true;
			transform.parent.Find ("triangle").gameObject.SetActive (true);
			source.PlayOneShot(audio_triangle, SliderControl.volume);
			Vector3 DrawTrianglePos = new Vector3(transform.parent.Find ("triangle").position.x - 0.5f, transform.parent.Find ("triangle").position.y + 0.5f, transform.parent.Find ("triangle").position.z);
			Instantiate(drawTriangle,DrawTrianglePos,transform.parent.Find ("triangle").rotation);
			if(temp!=null)
			{
				Destroy(temp);
			}
		}
		#if UNITY_EDITOR
		if (Input.GetKey(KeyCode.Space)&&coll.tag == "Player") {
			transform.parent.Find ("triangle").gameObject.SetActive (true);
			source.PlayOneShot(audio_triangle, 0.85f);
			Vector3 DrawTrianglePos = new Vector3(transform.parent.Find ("triangle").position.x - 0.5f, transform.parent.Find ("triangle").position.y + 0.5f, transform.parent.Find ("triangle").position.z);
			Instantiate(drawTriangle,DrawTrianglePos,transform.parent.Find ("triangle").rotation);
			if(temp!=null)
			{
				Destroy(temp);
			}
		}
		#endif
		if (Input.touchCount > 0 && coll.tag == "Player") {
			var touch = Input.GetTouch (0);
			switch (touch.phase) {
			case TouchPhase.Began:
				xstart = touch.position.x;
				ystart = touch.position.y;
				xchange_p = 0;
				ychange_p = 0;
				xchange_n = 0;
				ychange_n = 0;
				xchange_p_d = 0;
				xchange_n_d = 0;
				break;
			case TouchPhase.Moved:
				if (touch.position.x > xstart){
					if(xchange_p < Mathf.Abs (xstart - touch.position.x))
						xchange_p = Mathf.Abs (xstart - touch.position.x);	
					xchange_p_d = xchange_p_d+Mathf.Abs (xstart - touch.position.x);
				}
				if (touch.position.x < xstart){
					if(xchange_n < Mathf.Abs (xstart - touch.position.x))
						xchange_n = Mathf.Abs (xstart - touch.position.x);	
					xchange_n_d = xchange_n_d+Mathf.Abs (xstart - touch.position.x);
				}
				if (touch.position.y > ystart && ychange_p < Mathf.Abs (ystart - touch.position.y))
					ychange_p = Mathf.Abs (ystart - touch.position.y);	
				if (touch.position.y < ystart && ychange_n < Mathf.Abs (ystart - touch.position.y))
					ychange_n = Mathf.Abs (ystart - touch.position.y);
				break;
			case TouchPhase.Ended:
				if (xchange_n > val && ychange_n > val)
				{
					transform.parent.Find ("triangle").gameObject.SetActive (true);
					source.PlayOneShot(audio_triangle, SliderControl.volume);
					Vector3 DrawTrianglePos = new Vector3(transform.parent.Find ("triangle").position.x - 0.5f, transform.parent.Find ("triangle").position.y + 0.5f, transform.parent.Find ("triangle").position.z);
					Instantiate(drawTriangle,DrawTrianglePos,transform.parent.Find ("triangle").rotation);
					if(temp!=null)
						Destroy(temp);
				}
				break;
			}
		}
		
	}
}
