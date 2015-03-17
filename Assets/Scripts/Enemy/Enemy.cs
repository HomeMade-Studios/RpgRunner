using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int goldDrop;
	public int maxHealth, strenght;
	public float knockback;

	Character character;
	bool dropHealthPotion, dropManaPotion;
	int health, coinsDrop;
	Slider healthBar;
	Drop dropSystem;

	// Use this for initialization
	void Start () {
		//gold = GameObject.FindGameObjectWithTag ("Gold");
		//healthPotion = GameObject.FindGameObjectWithTag ("HealthPotion");
		//manaPotion = GameObject.FindGameObjectWithTag ("ManaPotion");

		character = GameObject.FindGameObjectWithTag ("Player").GetComponent<Character>();
		dropSystem = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Drop> ();
		healthBar = GetComponentInChildren <Slider>();
		health = maxHealth;
		DropSet ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, 50 * Time.deltaTime);
		healthBar.value = (float)(health*1)/maxHealth;
		if (health <= 0)
			Death ();
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			character.Hit(strenght);
		}
	}

	public void Hit (int strong){
		GetComponent<Rigidbody2D>().AddForce (new Vector2(knockback,0));
		health -= (int)(strong * Random.Range (0.5f, 1.5f));
	}

	void Death(){
		dropSystem.DropItem (coinsDrop, dropHealthPotion, dropManaPotion, transform.position);
		Destroy (gameObject);
	}

	void DropSet(){
		coinsDrop = (int)(goldDrop * Random.Range (0.5f, 1.5f));
		if (Random.Range (1, 20) == 1)
			dropHealthPotion = true;
		else
			dropHealthPotion = false;
		if (Random.Range (1, 15) == 1)
			dropManaPotion = true;
		else
			dropManaPotion = false;
	}


}
