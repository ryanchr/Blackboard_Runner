using UnityEngine;
using System.Collections;

public class TutorialStop : MonoBehaviour {
	private float xstart;
	private float ystart;
	private float xchange_p;
	private float ychange_p;
	private float xchange_n;
	private float ychange_n;
	private float xchange_p_d;
	private float xchange_n_d;
	public GameObject fingerdraw0;
	public GameObject fingerdraw1;
	public GameObject fingerdraw2;
	public GameObject fingerdrawtriangle;
	public GameObject fingerdrawlineup;
	private GameObject temp;
	//private bool comeIn = false;
	private int count = 0;

	void OnTriggerEnter2D(Collider2D coll) {
		++count;
		if ((count&1) == 0) {
			Vector3 DrawLinePos = new Vector3(transform.parent.Find ("line").position.x - 2.5f, transform.parent.Find ("line").position.y + 8.0f, transform.parent.Find ("line").position.z);
			if (transform.parent.name == "gap_1") {
				if(coll.tag == "Player")
				{
					temp = Instantiate(fingerdraw0, DrawLinePos,transform.parent.Find ("line").rotation) as GameObject;
					//Debug.Log("----0----");
				}
			} else if (transform.parent.name == "gap_2") {
				if(coll.tag == "Player")
				{
					temp = Instantiate(fingerdraw1, DrawLinePos,transform.parent.Find ("line").rotation) as GameObject;
					//Debug.Log("----1----");
				}
			} else if (transform.parent.name == "gap_3") {
				if(coll.tag == "Player")
				{
					temp = Instantiate(fingerdraw2, DrawLinePos,transform.parent.Find ("line").rotation) as GameObject;
					//Debug.Log("----2----");
				}
			} else if (transform.parent.name == "obstacle_1") {
				if(coll.tag == "Player")
				{
					temp = Instantiate(fingerdrawtriangle, DrawLinePos,transform.parent.Find ("line").rotation) as GameObject;
					//Debug.Log("----3----");
				}
			} else if (transform.parent.name == "obstacle_2") {
				if(coll.tag == "Player")
				{
					temp = Instantiate(fingerdrawlineup, DrawLinePos,transform.parent.Find ("line").rotation) as GameObject;
					//Debug.Log("----4----");
				}
			}
			//comeIn = true;
		}
		//Debug.Log ("-------------------------------");
	}

	void OnTriggerStay2D(Collider2D  coll) {
		if (transform.parent.name == "gap_1") {
			#if UNITY_EDITOR
			if (coll.tag == "Player" && Input.GetKey (KeyCode.DownArrow)) {
				transform.parent.Find ("stop").gameObject.SetActive (false);
				if(temp!=null)
				{
					Destroy(temp);
					//comeIn = false;
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
					if(xchange_n<60 && xchange_p>60 && ychange_p<60 && ychange_n<60){
						transform.parent.Find ("stop").gameObject.SetActive (false);
						if(temp!=null)
						{
							Destroy(temp);
							//comeIn = false;
						}
					}
					break;	
				}
			}
		} else if (transform.parent.name == "gap_2") {
			#if UNITY_EDITOR
			if (coll.tag == "Player" && Input.GetKey (KeyCode.DownArrow)) {
				transform.parent.Find ("stop").gameObject.SetActive (false);
				if(temp!=null)
				{
					Destroy(temp);
					//comeIn = false;
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
					if(xchange_n<60 && xchange_p>60 && ychange_n==0 && ychange_p>60){
						transform.parent.Find ("stop").gameObject.SetActive (false);
						if(temp!=null)
						{
							Destroy(temp);
							//comeIn = false;
						}
					}
					break;	
				}
			}
		} else if (transform.parent.name == "gap_3") {
			#if UNITY_EDITOR
			if (coll.tag == "Player" && Input.GetKey (KeyCode.DownArrow)) {
				transform.parent.Find ("stop").gameObject.SetActive (false);
				if(temp!=null)
				{
					Destroy(temp);
					//comeIn = false;
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
					if(xchange_n<60 && ychange_p==0 && ychange_n>60 && xchange_p>60 && Mathf.Abs(ystart-touch.position.y)>60) {
						transform.parent.Find ("stop").gameObject.SetActive (false);
						if(temp!=null)
						{
							Destroy(temp);
							//comeIn = false;
						}
					}
					break;	
				}
			}
		} else if (transform.parent.name == "obstacle_1") {
			#if UNITY_EDITOR
			if (coll.tag == "Player" && Input.GetKey (KeyCode.Space)) {
				transform.parent.Find ("stop").gameObject.SetActive (false);
				if(temp!=null)
				{
					Destroy(temp);
					//comeIn = false;
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
					if (xchange_n > 80 && ychange_n > 80)
					{
						transform.parent.Find ("stop").gameObject.SetActive (false);
						if(temp!=null)
						{
							Destroy(temp);
							//comeIn = false;
						}
					}
					break;
					
				}
			}
		} else if (transform.parent.name == "obstacle_2") {
			#if UNITY_EDITOR
			if (coll.tag == "Player" && Input.GetKey (KeyCode.Space)) {
				transform.parent.Find ("stop").gameObject.SetActive (false);
				if(temp!=null)
				{
					Destroy(temp);
					//comeIn = false;
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
					if (ychange_p > 80 && ychange_n < 80 && xchange_n < 80 && xchange_p< 80)
					{
						transform.parent.Find ("stop").gameObject.SetActive (false);
						if(temp!=null)
						{
							Destroy(temp);
							//comeIn = false;
						}
					}
					break;
					
				}
			}
		}
	}
}
