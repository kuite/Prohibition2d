using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControll : MonoBehaviour {

	Rigidbody2D rigiBody;

	private float speed = 5.0f;

	// Use this for initialization
	void Start () {
		rigiBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		KeyboardMovement ();
	}

	private void KeyboardMovement()
	{
		var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		//transform.position += move * speed * Time.deltaTime;

		rigiBody.velocity += new Vector2 (move.x, move.y);
	}
}
