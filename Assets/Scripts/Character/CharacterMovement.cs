using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public int speed, jumpForce;
	public Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		//GameObject.FindGameObjectsWithTag ("Enemy");

	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {

		}
	}

	void FixedUpdate () {
		rigidbody2D.velocity = (new Vector2 (speed, 0));
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy"){

		}
	}
}
