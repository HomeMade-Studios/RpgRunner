﻿using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {

	float startTime;
	GameObject goldCounter;
	// Use this for initialization
	void Start () {
		goldCounter = GameObject.FindGameObjectWithTag ("GoldCounter");
		startTime = Time.time;
		rigidbody2D.AddForce (new Vector2 (Random.Range (-5000, 5000), Random.Range (10000, 20000)));
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime >= 1.5) {
			rigidbody2D.isKinematic = true;
			transform.position = Vector2.MoveTowards (transform.position, goldCounter.transform.position, 800 * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "GoldCounter") {
			Destroy(gameObject);
		}
	}

}
