using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Character : MonoBehaviour {

	public int speed, jumpForce;
	int maxHealth, health, maxMana, mana;
	public Image healthBar;
	public Image manaBar;

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectsWithTag ("Enemy");
		maxHealth = 1000;
		maxMana = 100;
		health = maxHealth;
		mana = maxMana;
	}

	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2 (100, rigidbody2D.velocity.y);
		healthBar.fillAmount = (float)(health*1)/maxHealth;
		manaBar.fillAmount = (float)(mana*1)/maxMana;
	}

	public void attacked(int strong){
		health -= (int)(strong * Random.Range (0.5f, 1.5f)); 
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy"){

		}
	}
}
