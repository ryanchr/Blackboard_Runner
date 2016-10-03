using UnityEngine;
using System.Collections;

public class eatPaint : MonoBehaviour {

	public AudioClip audio_square;
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
	
	public GameObject drawSquare;
	public GameObject drawTriangle;
	public GameObject paint;
	private bool isDraw = false;
	
	void Start () {
		source = GetComponent<AudioSource> ();
		transform.parent.Find ("square").gameObject.SetActive (false);
		transform.parent.Find ("triangle").gameObject.SetActive (false);
		val = 80;
		float new_x = transform.parent.Find ("line").transform.position.x;
		float new_y = transform.parent.Find ("line").transform.position.y;
		int random = Random.Range (0, 2);
		if (random == 0) {
			Instantiate (paint, new Vector3 (new_x+0.6f, new_y + 7.5f, 0), transform.rotation);
			Instantiate (paint, new Vector3 (new_x-0.2f, new_y + 6f, 0), transform.rotation);
			Instantiate (paint, new Vector3 (new_x + 1.3f, new_y + 6f, 0), transform.rotation);
			Instantiate (paint, new Vector3 (new_x-1.1f, new_y + 4.5f, 0), transform.rotation);
			Instantiate (paint, new Vector3 (new_x + 2.2f, new_y + 4.5f, 0), transform.rotation);
		} else {
			Instantiate (paint, new Vector3 (new_x + 1.3f, new_y + 4.5f, 0), transform.rotation);
			Instantiate (paint, new Vector3 (new_x + 0.4f, new_y + 3f, 0), transform.rotation);
			Instantiate (paint, new Vector3 (new_x + 2.0f, new_y + 3f, 0), transform.rotation);
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		#if UNITY_EDITOR
		if (Input.GetKey(KeyCode.Z)&&coll.tag == "Player"&&!isDraw) {
			transform.parent.Find ("square").gameObject.SetActive (true);
			source.PlayOneShot(audio_square, 0.85f);
			Vector3 DrawSquarePos = new Vector3(transform.parent.Find ("square").position.x - 0.5f, transform.parent.Find ("square").position.y + 0.5f, transform.parent.Find ("square").position.z);
			Instantiate(drawSquare,DrawSquarePos,transform.parent.Find ("square").rotation);
			isDraw = true;
		}
		if (Input.GetKey(KeyCode.X)&&coll.tag == "Player"&&!isDraw) {
			transform.parent.Find ("triangle").gameObject.SetActive (true);
			source.PlayOneShot(audio_square, SliderControl.volume);
			Vector3 DrawTrianglePos = new Vector3(transform.parent.Find ("triangle").position.x - 0.5f, transform.parent.Find ("triangle").position.y + 0.5f, transform.parent.Find ("triangle").position.z);
			Instantiate(drawTriangle,DrawTrianglePos,transform.parent.Find ("triangle").rotation);
			isDraw = true;
		}
		#endif
		if (Input.touchCount > 0 && coll.tag == "Player"&&!isDraw) {
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
					source.PlayOneShot(audio_square, SliderControl.volume);
					Vector3 DrawTrianglePos = new Vector3(transform.parent.Find ("triangle").position.x - 0.5f, transform.parent.Find ("triangle").position.y + 0.5f, transform.parent.Find ("triangle").position.z);
					Instantiate(drawTriangle,DrawTrianglePos,transform.parent.Find ("triangle").rotation);
					isDraw = true;
				}
				if (ychange_p > val && ychange_n < val && xchange_n < val && xchange_p< val)
				{
					transform.parent.Find ("square").gameObject.SetActive (true);
					source.PlayOneShot(audio_square, SliderControl.volume);
					Vector3 DrawSquarePos = new Vector3(transform.parent.Find ("square").position.x - 0.5f, transform.parent.Find ("square").position.y + 0.5f, transform.parent.Find ("square").position.z);
					Instantiate(drawSquare,DrawSquarePos,transform.parent.Find ("square").rotation);
					isDraw = true;
					
				}
				break;
			}
		}
	}
	
	void OnTriggerStay2D(Collider2D coll)
	{
		#if UNITY_EDITOR
		if (Input.GetKey(KeyCode.Z)&&coll.tag == "Player"&&!isDraw) {
			transform.parent.Find ("square").gameObject.SetActive (true);
			source.PlayOneShot(audio_square, 0.85f);
			Vector3 DrawSquarePos = new Vector3(transform.parent.Find ("square").position.x - 0.5f, transform.parent.Find ("square").position.y + 0.5f, transform.parent.Find ("square").position.z);
			Instantiate(drawSquare,DrawSquarePos,transform.parent.Find ("square").rotation);
			isDraw = true;
		}
		if (Input.GetKey(KeyCode.X)&&coll.tag == "Player"&&!isDraw) {
			transform.parent.Find ("triangle").gameObject.SetActive (true);
			source.PlayOneShot(audio_square, SliderControl.volume);
			Vector3 DrawTrianglePos = new Vector3(transform.parent.Find ("triangle").position.x - 0.5f, transform.parent.Find ("triangle").position.y + 0.5f, transform.parent.Find ("triangle").position.z);
			Instantiate(drawTriangle,DrawTrianglePos,transform.parent.Find ("triangle").rotation);
			isDraw = true;
		}
		#endif
		if (Input.touchCount > 0 && coll.tag == "Player"&&!isDraw) {
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
					source.PlayOneShot(audio_square, SliderControl.volume);
					Vector3 DrawTrianglePos = new Vector3(transform.parent.Find ("triangle").position.x - 0.5f, transform.parent.Find ("triangle").position.y + 0.5f, transform.parent.Find ("triangle").position.z);
					Instantiate(drawTriangle,DrawTrianglePos,transform.parent.Find ("triangle").rotation);
					isDraw = true;
				}
				if (ychange_p > val && ychange_n < val && xchange_n < val && xchange_p< val)
				{
					transform.parent.Find ("square").gameObject.SetActive (true);
					source.PlayOneShot(audio_square, SliderControl.volume);
					Vector3 DrawSquarePos = new Vector3(transform.parent.Find ("square").position.x - 0.5f, transform.parent.Find ("square").position.y + 0.5f, transform.parent.Find ("square").position.z);
					Instantiate(drawSquare,DrawSquarePos,transform.parent.Find ("square").rotation);
					isDraw = true;
					
				}
				break;
				
			}
		}
	}
}
