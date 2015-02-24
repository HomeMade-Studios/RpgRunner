using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float knowback;
	public int maxLife, strong;
	CharacterMovement character;
	int life; 
	Slider healt;

	// Use this for initialization
	void Start () {
		character = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterMovement>();
		healt = GetComponentInChildren <Slider>();
		life = maxLife;
		Physics.IgnoreLayerCollision(8,8);
	}
	
	// Update is called once per frame
	void Update () {
		healt.value = (float)(life*1)/maxLife;
		if (life <= 0)
			Destroy(gameObject);
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			life -= 10;
			character.attacked(strong);
			rigidbody2D.AddForce (new Vector2(knowback,0));


		}
	}
}
