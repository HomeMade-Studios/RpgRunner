using UnityEngine;
using System.Collections;

public class GoldDropping : MonoBehaviour {

	GameObject goldIcon;
	float startTime;
	//GameObject goldCounter;
	// Use this for initialization
	void Start () {
		goldIcon = GameObject.FindGameObjectWithTag ("GoldIcon");
		transform.parent = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Transform>();
		startTime = Time.time;
		GetComponent<Rigidbody2D>().AddForce (new Vector2 (Random.Range (-2500, 2500), Random.Range (7500, 12000)));
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime >= 1) {
			GetComponent<Rigidbody2D>().isKinematic = true;
			transform.position = Vector2.MoveTowards (transform.position, goldIcon.transform.position, 500 * Time.deltaTime);}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "GoldIcon") {
			Destroy(gameObject);
		}
	}

}
