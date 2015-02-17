using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public int speed, jumpForce;
	public Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		GameObject.FindGameObjectsWithTag ("Ground");
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (speed, 0, 0);
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
		if(other.gameObject.tag == "Ground"){
			animator.SetBool("isJumping", false);
			animator.SetBool("isMoving", true);
		}
	}
}
