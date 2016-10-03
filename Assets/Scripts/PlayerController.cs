using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed;
	
	public AudioClip audio_jump;
	public AudioClip audio_water;
	public AudioClip audio_paints;
	public AudioClip audio_box;
	private AudioSource source;
	
	private bool isJump = false;
	private bool isInGap = false;  //avoid reduce paint twice
	private bool isDown = false;
	//private bool isMoveSpeedUp = false;
	
	// 0: normal, 1: increase movespeed 2: decrease movespeed 3: help fill gaps
	private int status = 0;
	public bool isHelpfilled = false;
	
	private float xstart;
	private float ystart;
	private float xchange;
	private float ychange;
	
	private Animator anim;
	
	public GameObject csPaintCount;
	public GameObject cam;
	
	public static int Eaten_chalk_or_box_number;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		source = GetComponent<AudioSource> ();
		InvokeRepeating("VelocityIncrease",0f,1.0f);
		Eaten_chalk_or_box_number = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -28)
			//Application.LoadLevel("GameOver");
			Die ();
		if(isJump&&GetComponent<Rigidbody2D> ().velocity.y<0)
		{
			GetComponent<Rigidbody2D> ().gravityScale = 1.75f;
		}
		
		anim.SetBool ("Ground", !isJump);
	}
	
	void OnCollisionExit2D(Collision2D coll)
	{
		if (!isJump) {
			if (coll.gameObject.layer.Equals (LayerMask.NameToLayer ("Ground_1"))) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed/1.2f, -moveSpeed / 2);	
			} else if (coll.gameObject.layer.Equals (LayerMask.NameToLayer ("Ground_2"))) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, 0);
			} 
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.layer.Equals (LayerMask.NameToLayer ("Ground_1"))) {
			GetComponent<Rigidbody2D> ().gravityScale = 1;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			isJump = false;
			isInGap = false;
		} else if (coll.gameObject.layer.Equals (LayerMask.NameToLayer ("Ground_2"))) {
			GetComponent<Rigidbody2D> ().gravityScale = 1;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, moveSpeed / 2);
			isJump = false;
			isInGap = false;
		} else if (coll.gameObject.layer.Equals (LayerMask.NameToLayer ("Ground_3"))) {
			GetComponent<Rigidbody2D> ().gravityScale = 1;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, -moveSpeed / 2);
			isJump = false;
			isInGap = false;
		}
	}
	
	void OnCollisionStay2D(Collision2D coll)
	{
		if (!isJump) {
			if (coll.gameObject.layer.Equals (LayerMask.NameToLayer ("Ground_1"))) {
				GetComponent<Rigidbody2D> ().gravityScale = 1;
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
				isJump = false;
			} else if (coll.gameObject.layer.Equals (LayerMask.NameToLayer ("Ground_2"))) {
				GetComponent<Rigidbody2D> ().gravityScale = 1;
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, moveSpeed / 2);
				isJump = false;
			} else if (coll.gameObject.layer.Equals (LayerMask.NameToLayer ("Ground_3"))) {
				GetComponent<Rigidbody2D> ().gravityScale = 1;
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, -moveSpeed / 2);
				isJump = false;
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "down") {
			//Debug.Log("--------------isFalling--------------");
			isDown = true;
			Debug.Log (isDown);
			anim.SetBool ("Ground", false);
			anim.SetBool ("Fall", isDown);
			
		} else if (col.tag == "water") {
			source.PlayOneShot(audio_water, SliderControl.volume);
			
		}else if (col.tag == "gap") {
			/*if(!isInGap)
			{
				if(PaintCount.Instance.getNumberOfPaint()<3){
					Application.LoadLevel("GameOver");
				} else{
					isJump = true;
					isDown = false;
					anim.SetBool ("Fall", isDown);
					GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
					float new_x = col.transform.parent.Find("line").transform.position.x +3f;
					float new_y = col.transform.parent.Find("line").transform.position.y +5f;
					GetComponent<Rigidbody2D> ().transform.position = new Vector2(new_x, new_y);
					PaintCount.Instance.RmPaint(3);
					isInGap = true;
				}
			}*/
			//Application.LoadLevel("GameOver");
			Die();
		}else if (col.tag == "triangle") {
			jump();
		}else if (col.tag == "square") {
			jumpHigher();
		}else if (col.tag == "paint") {
			source.PlayOneShot(audio_paints, SliderControl.volume);
			Destroy (col.gameObject);
			Eaten_chalk_or_box_number++;
		}else if (col.tag == "box") {
			Destroy (col.gameObject);
			Eaten_chalk_or_box_number++;
			source.PlayOneShot(audio_box, SliderControl.volume);
			changeStatus();		
			anim.SetInteger ("Status", status);
		}
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "triangle") {
			jump();
		}else if (col.tag == "square") {
			jumpHigher();
		}
	}
	
	//for triangle
	public void jump(){
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		GetComponent<Rigidbody2D>().velocity = new Vector2 (4.0f,6.5f);
		source.PlayOneShot(audio_jump, SliderControl.volume);
		isJump = true;
	}
	
	//for square
	public void jumpHigher(){
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		GetComponent<Rigidbody2D>().velocity = new Vector2 (3.2f,10.0f);
		source.PlayOneShot(audio_jump, SliderControl.volume);
		isJump = true;
	}
	
	//normal jump
	public void jumpLower(){
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		GetComponent<Rigidbody2D>().velocity = new Vector2 (2.0f,GetComponent<Rigidbody2D> ().velocity.y+8.0f);
		source.PlayOneShot(audio_jump, SliderControl.volume);
		isJump = true;
	}
	
	public void VelocityIncrease()
	{
		if (moveSpeed <= 16.0f) {
			moveSpeed += 0.1f * DifficultyControl.difficulty;
			//Debug.Log (moveSpeed);
		}
	}
	
	public void changeStatus()
	{
		int paintColor = Random.Range(0,4);
		if (paintColor == 0) {
			if (status == 0) {
				moveSpeed += 2;
				status = 1;
				Debug.Log ("**********Red paint(0-1)**********");
				Invoke ("Recover", 10.0f);
			} else if (status == 1) {
				status = 1;
				Debug.Log ("**********Red paint(1-1)**********");
				CancelInvoke ("Recover");
				Invoke ("Recover", 10.0f);
			} else if (status == 2) {
				CancelInvoke ("Recover");
				Recover();
				status = 1;
				moveSpeed += 2;
				Debug.Log ("**********Red paint(2-1)**********");
				Invoke ("Recover", 10.0f);
			}
		} else if (paintColor == 1) {
			if (status == 0) {
				moveSpeed -= 2;
				status = 2;
				Debug.Log ("!!!!!!!Blue paint(0-2)!!!!!!!");
				Invoke ("Recover", 10.0f);
			} else if (status == 1) {
				CancelInvoke ("Recover");
				Recover ();
				status = 2;
				moveSpeed-=2;
				Debug.Log ("!!!!!!!Blue paint(1-2)!!!!!!!");
				Invoke ("Recover", 10.0f);
			} else if (status == 2) {
				status = 2;
				Debug.Log ("!!!!!!!Blue paint(2-2)!!!!!!!");
				CancelInvoke ("Recover");
				Invoke ("Recover", 10.0f);
			}
		} else if (paintColor == 2) {
			if (status == 0) {
				status = 3;
				isHelpfilled = true;
				moveSpeed += 3;
				Debug.Log ("-------------------Yellow paint(0-3)-------------------");
				Invoke ("Recover", 10.0f);
			} else if (status == 1) {
				CancelInvoke ("Recover");
				Recover();
				status = 3;
				isHelpfilled = true;
				moveSpeed += 3;
				Debug.Log ("-------------------Yellow paint(1-3)-------------------");
				Invoke ("Recover", 10.0f);
			} else if (status == 2) {
				CancelInvoke ("Recover");
				Recover();
				status = 3;
				isHelpfilled = true;
				moveSpeed += 3;
				Debug.Log ("-------------------Yellow paint(2-3)-------------------");
				Invoke ("Recover", 10.0f);
			}else if(status==3)
			{
				status = 3;
				CancelInvoke ("Recover");
				Debug.Log ("-------------------Yellow paint(3-3)-------------------");
				Invoke ("Recover", 10.0f);
			}
		}else if(paintColor == 3){
			if (status == 0) {
				status = 4;
				cam.GetComponent<CameraFollow>().flip();
				Debug.Log (">>>>>>>>>Black paint(0-4)<<<<<<<<<<<");
				Invoke ("Recover", 10.0f);
			} else if (status == 1) {
				CancelInvoke ("Recover");
				Recover();
				status = 4;
				cam.GetComponent<CameraFollow>().flip();
				Debug.Log (">>>>>>>>>Black paint(1-4)<<<<<<<<<<<");
				Invoke ("Recover", 10.0f);
			} else if (status == 2) {
				CancelInvoke ("Recover");
				Recover();
				status = 4;
				cam.GetComponent<CameraFollow>().flip();
				Debug.Log (">>>>>>>>>Black paint(2-4)<<<<<<<<<<<");
				Invoke ("Recover", 10.0f);
			}else if(status==4){
				CancelInvoke ("Recover");
				status = 4;
				Debug.Log (">>>>>>>>>Black paint(4-4)<<<<<<<<<<<");
				Invoke ("Recover", 10.0f);
			}
		}
	}
	
	public void Recover()
	{
		anim.SetInteger ("Status", 0);
		switch (status) 
		{
		case 1:
			moveSpeed -= 2;
			status = 0;
			Debug.Log("-----Recover1-----");
			break;
		case 2:
			moveSpeed += 2;
			status = 0;
			Debug.Log("-----Recover2----");
			break;
		case 3:
			moveSpeed -= 3;
			status = 0;
			isHelpfilled = false;
			Debug.Log("-----Recover3----");
			break;
		case 4:
			status = 0;
			cam.GetComponent<CameraFollow>().reflip();
			Debug.Log("-----Recover4----");
			break;
		}
		
	}
	
	void Die()
	{
		if (ScoreLabel.score > HighScoreContainer.highscore3)
			Application.LoadLevel ("GameOver");
		else
			Application.LoadLevel ("Gameover2");
	}
}
