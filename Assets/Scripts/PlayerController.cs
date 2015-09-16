using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpHeight;
	public float moveSpeed;


	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		if(/*Input.GetKey(KeyCode.RightArrow) &&*/ grounded){
			GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
	}

	// Update is called once per frame
	void Update () {
		if (grounded)
		if(Input.GetKeyDown(KeyCode.UpArrow) && grounded){
			jump ();
		}
		//if(Input.GetKey(KeyCode.LeftArrow) && grounded){
		//	GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		//}
		//if(/*Input.GetKey(KeyCode.RightArrow) &&*/ grounded){
		//	GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		//}
		anim.SetBool ("Ground", grounded);
	}
	public void jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
}
