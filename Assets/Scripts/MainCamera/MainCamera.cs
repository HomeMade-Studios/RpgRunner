using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public GameObject Enemy01;
	public Transform player;
	int spawn = 0;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform; 
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3 (player.position.x+200, 0, -10);
		if (spawn == 150) {
			Instantiate (Enemy01, new Vector3(player.position.x + 100, player.position.y, player.position.z), transform.rotation);
			spawn = 0;
		} else
			spawn++;
	}
}
