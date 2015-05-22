using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MainCamera : MonoBehaviour {


    void Awake()
    {
        Camera.main.orthographicSize = Screen.height / 2;
    }
	// Use this for initialization
	void Start () {

	}
	void FixedUpdate ()
	{
        Camera.main.transform.position = new Vector3 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), transform.position.y) + new Vector3(-0.1f, -0.1f, 0);    
	}
}
