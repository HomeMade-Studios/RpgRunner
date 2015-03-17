using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour {

	public GameObject gold, healthPotion, manaPotion;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DropItem(int goldDrop, bool dropHealthPotion, bool dropManaPotion, Vector2 transformPosition){
		for (int i = 0; i < goldDrop; i++) {
			Instantiate (gold, transformPosition, transform.rotation);
		}
		if(dropHealthPotion)
			Instantiate (healthPotion, transformPosition, transform.rotation);
		if(dropManaPotion)
			Instantiate (manaPotion, transformPosition, transform.rotation);
	}
}
