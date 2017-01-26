using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour {
	private Rigidbody2D rigi;
	private Stack waypointsStack = new Stack ();
	public Vector2 destinationVector;
	private Vector2[] waypoints;
	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody2D>();
		destinationVector = transform.position;
		waypoints = PathFindingScript.RequestPath (new Vector2(0.0f, 0.0f), new Vector2(0.0f, 4.0f));
		foreach (Vector2 point in waypoints) {
			waypointsStack.Push (point);
		}
	}
	
	// Update is called once per frame
	void Update () {
		FollowWaypoints ();
	}

	private bool Approach(Vector2 wayP)//float x, float y)
	{
		float approachSpeed = 0.5f;
		Vector2 approachDestination = new Vector2(wayP.x, wayP.y);
		Vector2 myPoss = rigi.position;

		if (Vector2.Distance(approachDestination, myPoss) < 0.2f)
		{
			rigi.velocity = new Vector2(0f, 0f);
			return true;
		}

		rigi.velocity = new Vector2(approachSpeed * (approachDestination.x - myPoss.x) / Vector2.Distance(approachDestination, myPoss), approachSpeed * (approachDestination.y - myPoss.y) / Vector2.Distance(approachDestination, myPoss));
		return false;
	}

	void FollowWaypoints(){
		if (Approach (destinationVector) && waypointsStack.Count > 0) {
			destinationVector = (Vector2)waypointsStack.Pop ();
		}
	}
}
