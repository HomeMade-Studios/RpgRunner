using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public int speed, jumpForce;
	int maxLife = 1000, life;
	public Animator animator;
	public Vector2 movement = new Vector3(1,0,0);

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		GameObject.FindGameObjectsWithTag ("Enemy");
		life = maxLife;

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

	public void attacked(int strong){
		life -= (int)(strong * Random.Range (0.5f, 1.5f)); 
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy"){

		}
		if(other.gameObject.tag == "Ground"){
			animator.SetBool ("isJumping", false);
			animator.SetBool ("isMoving", true);
		}
	}
}
