using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour {
	private Rigidbody2D rigi;

	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Approach (3.0f, 3.0f);
	}

	private bool Approach(float x, float y)
	{
		float approachSpeed = 3;
		Vector2 approachDestination = new Vector2(x, y);
		Vector2 myPoss = rigi.position;

		if (Vector2.Distance(approachDestination, myPoss) < 0.2f)
		{
			rigi.velocity = new Vector2(0f, 0f);
			return true;
		}

		rigi.velocity = new Vector2(approachSpeed * (approachDestination.x - myPoss.x) / Vector2.Distance(approachDestination, myPoss), approachSpeed * (approachDestination.y - myPoss.y) / Vector2.Distance(approachDestination, myPoss));
		return false;
	}
}
