using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public int speed, jumpForce;
	public Animator animator;
	public Vector2 movement = new Vector3(1,0,0);

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		GameObject.FindGameObjectsWithTag ("Enemy");

	}

	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2 (100, rigidbody2D.velocity.y);
		if ( Input.GetKeyDown(KeyCode.Space) && !animator.GetBool("isJumping")) {
			rigidbody2D.AddForce (Vector2.up * jumpForce);
			animator.SetBool("isJumping", true);
			animator.SetBool("isMoving", false);
		}
		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Began && !animator.GetBool ("isJumping")) {
				rigidbody2D.AddForce (Vector2.up * jumpForce);
				animator.SetBool ("isJumping", true);
				animator.SetBool ("isMoving", false);
			}
			
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy"){

		}
		if(other.gameObject.tag == "Ground"){
			animator.SetBool ("isJumping", false);
		}
	}
}
