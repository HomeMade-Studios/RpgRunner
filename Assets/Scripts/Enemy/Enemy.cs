using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float knowback;
	public int maxHealth, strong;
	Character character;
	int health;
	Slider healthBar;

	// Use this for initialization
	void Start () {
		character = GameObject.FindGameObjectWithTag ("Player").GetComponent<Character>();
		healthBar = GetComponentInChildren <Slider>();
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.value = (float)(health*1)/maxHealth;
		if (health <= 0)
			Destroy(gameObject);
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			health -= 10;
			character.attacked(strong);
			rigidbody2D.AddForce (new Vector2(knowback,0));
		}
	}
}
