using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public GameObject Enemy01;
	Transform player;
	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.AutoRotation;
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		player = GameObject.FindGameObjectWithTag ("Player").transform; 
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3 (player.position.x+200, 0, -10);
	}
}
