using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour {

	static GameObject gold, healthPotion, manaPotion;

    void Awake(){
        gold = Resources.Load("Prefabs/Drops/Gold", typeof(GameObject)) as GameObject;
        healthPotion = Resources.Load("Prefabs/Drops/HealthPotion", typeof(GameObject)) as GameObject;
        manaPotion = Resources.Load("Prefabs/Drops/ManaPotion", typeof(GameObject)) as GameObject;
    }

	public static void DropItem(int goldDrop, bool dropHealthPotion, bool dropManaPotion, Vector2 transformPosition){
		for (int i = 0; i < goldDrop; i++)
        {
			Instantiate (gold, transformPosition, Quaternion.identity);
		}

        if (dropHealthPotion)
        {
            Instantiate(healthPotion, transformPosition, Quaternion.identity);
        }

        if (dropManaPotion)
        {
            Instantiate(manaPotion, transformPosition, Quaternion.identity);
        }
	}
}
