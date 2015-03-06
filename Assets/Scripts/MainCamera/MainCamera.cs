using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public GameObject Enemy01;
	Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform; 
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3 (player.position.x+200, 0, -10);
	}
}
