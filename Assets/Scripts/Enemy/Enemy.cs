using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int goldDrop;
	public int maxHealth, strenght;
	
    float knockback;
    Transform playerTransform;
	bool dropHealthPotion, dropManaPotion;
	int health, coinsDrop;
	Slider healthBar;

	
    void Awake(){
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		healthBar = GetComponentInChildren <Slider>();
		health = maxHealth;
        knockback = 200;
    }

	void Start () {
		DropSet ();
	}
	
	void FixedUpdate () {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, 50 * Time.deltaTime);
	}

    void Update() {
        healthBar.value = (float)(health * 1) / maxHealth;
        if (health <= 0)
            Death();
    }

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player") {
			Player.Hit(strenght);
		}
	}

	public void Hit (int strong){
		GetComponent<Rigidbody2D>().AddForce (new Vector2 (knockback, 0), ForceMode2D.Impulse);
		health -= (int)(strong * Random.Range (0.5f, 1.5f));
	}

	void Death(){
		Drop.DropItem (coinsDrop, dropHealthPotion, dropManaPotion, transform.position);
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
