using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int minGoldDrop, maxGoldDrop;
	public int maxHealth, strenght;
	public float knockback;
	public GameObject gold, healthPotion, manaPotion;
	Character character;
	bool dropHealthPotion, dropManaPotion;
	int health, coinsDrop;
	Slider healthBar;

	// Use this for initialization
	void Start () {
		//gold = GameObject.FindGameObjectWithTag ("Gold");
		//healthPotion = GameObject.FindGameObjectWithTag ("HealthPotion");
		//manaPotion = GameObject.FindGameObjectWithTag ("ManaPotion");
		character = GameObject.FindGameObjectWithTag ("Player").GetComponent<Character>();
		healthBar = GetComponentInChildren <Slider>();
		health = maxHealth;
		DropSet ();
	}
	
	// Update is called once per frame
	void Update () {
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
		Drop ();
		Destroy (gameObject);
	}

	void Drop(){
		for (int i = 0; i < coinsDrop; i++) {
			Instantiate (gold, transform.position, transform.rotation);
		}
		if(dropHealthPotion)
			Instantiate (healthPotion, transform.position, transform.rotation);
		if(dropManaPotion)
			Instantiate (manaPotion, transform.position, transform.rotation);
	}

	void DropSet(){
		coinsDrop = Random.Range (minGoldDrop, maxGoldDrop);
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
