using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public GameObject Enemy01;
	Transform player;
	int spawn = 0;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform; 
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (spawn == 150) {
			Instantiate (Enemy01, new Vector3(player.position.x + 100, player.position.y, player.position.z), transform.rotation);
			spawn = 0;
		} else
			spawn++;
	}
}
