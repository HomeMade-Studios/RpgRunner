using UnityEngine;
using System.Collections;

public class ManaPotionDropping : MonoBehaviour {

	//GameObject manaPotionButton;
	float startTime;
	// Use this for initialization
	void Start () {
		//manaPotionButton = GameObject.FindGameObjectWithTag ("ManaPotionButton");
		transform.parent = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Transform>();
		startTime = Time.time;
		GetComponent<Rigidbody2D>().AddForce (new Vector2 (Random.Range (-5000, 5000), Random.Range (10000, 20000)));
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime >= 1.5) {
			GetComponent<Rigidbody2D>().isKinematic = true;
			//transform.position = Vector2.MoveTowards (transform.position, manaPotionButton.transform.position, 800 * Time.deltaTime);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "ManaPotionButton") {
			Destroy(gameObject);
		}
	}
}
