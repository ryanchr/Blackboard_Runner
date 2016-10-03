using UnityEngine;
using System.Collections;

public class ShowLine : MonoBehaviour {

	// Use this for initialization
	public AudioClip audio_line;
	private AudioSource source;

	private float xstart;
	private float ystart;
	private float xchange_p;
	private float ychange_p;
	private float xchange_n;
	private float ychange_n;
	private float val;

	public GameObject drawline;
	public GameObject attention;
	private GameObject temp;
	private bool comeIn = false;
	private bool isFilled = false;

	void Start () {
		//GameObject.Find("line").SetActive(false);
		source = GetComponent<AudioSource> ();
		transform.parent.Find ("line").gameObject.SetActive (false);
		val = 60;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(!comeIn){
			if (coll.tag == "Player") {
				temp = Instantiate (attention, transform.parent.Find ("line").position, Quaternion.identity) as GameObject;
				comeIn = true;
			}
		}
		if (coll.tag == "Player" && GameObject.Find ("Player").GetComponent<PlayerController> ().isHelpfilled) 
		{
			isFilled = true;
			transform.parent.Find ("line").gameObject.SetActive (true);
			source.PlayOneShot(audio_line, SliderControl.volume);
			Vector3 DrawLinePos = new Vector3(transform.parent.Find ("line").position.x - 2.5f, transform.parent.Find ("line").position.y, transform.parent.Find ("line").position.z);
			Instantiate(drawline,DrawLinePos,transform.parent.Find ("line").rotation);
			if(temp!=null)
			{
				Destroy(temp);
			}
		}
		#if UNITY_EDITOR
		if (Input.GetKey(KeyCode.DownArrow)&&coll.tag == "Player" ) {
			transform.parent.Find ("line").gameObject.SetActive (true);
			source.PlayOneShot(audio_line, SliderControl.volume);
			Vector3 DrawLinePos = new Vector3(transform.parent.Find ("line").position.x - 2.5f, transform.parent.Find ("line").position.y, transform.parent.Find ("line").position.z);
			Instantiate(drawline,DrawLinePos,transform.parent.Find ("line").rotation);
		}
		#endif
		if (Input.touchCount>0 && coll.tag == "Player") {
			var touch = Input.GetTouch (0);
			switch(touch.phase){
			case TouchPhase.Began:
				xstart=touch.position.x;
				ystart=touch.position.y;
				xchange_p=0;
				ychange_p=0;
				xchange_n=0;
				ychange_n=0;
				break;
			case TouchPhase.Moved:
				if(touch.position.x>xstart && xchange_p < Mathf.Abs(xstart-touch.position.x))
					xchange_p = Mathf.Abs(xstart-touch.position.x);	
				if(touch.position.x<xstart && xchange_n < Mathf.Abs(xstart-touch.position.x))
					xchange_n = Mathf.Abs(xstart-touch.position.x);	
				if(touch.position.y>ystart && ychange_p < Mathf.Abs(ystart-touch.position.y))
					ychange_p = Mathf.Abs(ystart-touch.position.y);	
				if(touch.position.y<ystart && ychange_n < Mathf.Abs(ystart-touch.position.y))
					ychange_n = Mathf.Abs(ystart-touch.position.y);
				break;
			case TouchPhase.Ended:
				if(xchange_n<val && xchange_p>val && ychange_p<val && ychange_n<val){
					transform.parent.Find ("line").gameObject.SetActive (true);
					source.PlayOneShot(audio_line, SliderControl.volume);
					Vector3 DrawLinePos = new Vector3(transform.parent.Find ("line").position.x - 2.5f, transform.parent.Find ("line").position.y, transform.parent.Find ("line").position.z);
					Instantiate(drawline,DrawLinePos,transform.parent.Find ("line").rotation);
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
			transform.parent.Find ("line").gameObject.SetActive (true);
			source.PlayOneShot(audio_line, SliderControl.volume);
			Vector3 DrawLinePos = new Vector3(transform.parent.Find ("line").position.x - 2.5f, transform.parent.Find ("line").position.y, transform.parent.Find ("line").position.z);
			Instantiate(drawline,DrawLinePos,transform.parent.Find ("line").rotation);
			if(temp!=null)
			{
				Destroy(temp);
			}
		}
		#if UNITY_EDITOR
		if (Input.GetKey(KeyCode.DownArrow)&&coll.tag == "Player" ) {
			transform.parent.Find ("line").gameObject.SetActive (true);
			source.PlayOneShot(audio_line, SliderControl.volume);
			Vector3 DrawLinePos = new Vector3(transform.parent.Find ("line").position.x - 2.5f, transform.parent.Find ("line").position.y, transform.parent.Find ("line").position.z);
			Instantiate(drawline,DrawLinePos,transform.parent.Find ("line").rotation);
			if(temp!=null)
			{
				Destroy(temp);
			}
		}
		#endif
		if (Input.touchCount>0 && coll.tag == "Player") {
			var touch = Input.GetTouch (0);
			switch(touch.phase){
			case TouchPhase.Began:
				xstart=touch.position.x;
				ystart=touch.position.y;
				xchange_p=0;
				ychange_p=0;
				xchange_n=0;
				ychange_n=0;
				break;
			case TouchPhase.Moved:
				if(touch.position.x>xstart && xchange_p < Mathf.Abs(xstart-touch.position.x))
					xchange_p = Mathf.Abs(xstart-touch.position.x);	
				if(touch.position.x<xstart && xchange_n < Mathf.Abs(xstart-touch.position.x))
					xchange_n = Mathf.Abs(xstart-touch.position.x);	
				if(touch.position.y>ystart && ychange_p < Mathf.Abs(ystart-touch.position.y))
					ychange_p = Mathf.Abs(ystart-touch.position.y);	
				if(touch.position.y<ystart && ychange_n < Mathf.Abs(ystart-touch.position.y))
					ychange_n = Mathf.Abs(ystart-touch.position.y);
				break;
			case TouchPhase.Ended:
				if(xchange_n<val && xchange_p>val && ychange_p<val && ychange_n<val){
					transform.parent.Find ("line").gameObject.SetActive (true);
					source.PlayOneShot(audio_line, SliderControl.volume);
					Vector3 DrawLinePos = new Vector3(transform.parent.Find ("line").position.x - 2.5f, transform.parent.Find ("line").position.y, transform.parent.Find ("line").position.z);
					Instantiate(drawline,DrawLinePos,transform.parent.Find ("line").rotation);
					if(temp!=null)
						Destroy(temp);

				}
				break;	
			}
		}

	}

}
 