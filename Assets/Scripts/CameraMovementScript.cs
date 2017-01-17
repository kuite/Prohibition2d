using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour {
	private float speed = 1.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		keyboardMovement ();
	}

	private void keyboardMovement()
	{
		//var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		var move = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f).normalized;
		transform.position += move * speed * Time.deltaTime;
	}
}
