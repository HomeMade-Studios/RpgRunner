using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Character : MonoBehaviour {

	public int speed, jumpForce;
	int maxHealth, health, maxMana, mana, strenght;
	int goldAmount, skillBooksAmount, gemsAmount;
	Image healthBar;
	Image manaBar;
	GameObject gold;
	GameObject skillBooks;
	GameObject gems;
	Enemy enemy;

	// Use this for initialization
	void Start () {
		gold = GameObject.FindGameObjectWithTag ("GoldIcon");
		skillBooks = GameObject.FindGameObjectWithTag ("SkillBooksIcon");
		gems = GameObject.FindGameObjectWithTag ("GemsIcon");
		manaBar = GameObject.FindGameObjectWithTag ("ManaBar").GetComponent<Image>();
		healthBar = GameObject.FindGameObjectWithTag ("HealthBar").GetComponent<Image>();
		maxHealth = 1000;
		maxMana = 100;
		health = maxHealth;
		mana = maxMana;
		strenght = 50;
		goldAmount = 0;
		skillBooksAmount = 0;
		gemsAmount = 0;
	}

	// Update is called once per frame
	void Update () {
		HudUpdate ();
		ValueUpdate ();
	}

	public void Hit(int enemyStrenght){
		health -= (int)(enemyStrenght * Random.Range (0.5f, 1.5f)); 
	}

	void HudUpdate(){
		healthBar.fillAmount = (float)(health*1)/maxHealth;
		manaBar.fillAmount = (float)(mana*1)/maxMana;
		healthBar.GetComponentInChildren<Text>().text = health + "/" + maxHealth;
		manaBar.GetComponentInChildren<Text>().text = mana + "/" + maxMana;
	}

	void ValueUpdate(){
		gold.GetComponentInChildren<Text>().text = goldAmount.ToString();
		skillBooks.GetComponentInChildren<Text>().text = skillBooksAmount.ToString();
		gems.GetComponentInChildren<Text>().text = gemsAmount.ToString();
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy"){
			enemy = other.gameObject.GetComponent<Enemy>();
			enemy.Hit(strenght);
		}
	}
}
