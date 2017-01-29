using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour {
	private Rigidbody2D rigi;
	private Stack waypointsStack = new Stack ();
	public Vector2 destinationVector;
	private Vector2[] waypoints;
	private float reloaded;
	public GameObject bulletPref;
	public GameObject bulletSpawn;
	public GameObject enemy;
	public LayerMask unwalkableMask;
	// Use this for initialization

	void Start () {
		reloaded = Time.time;
		rigi = GetComponent<Rigidbody2D>();
		destinationVector = transform.position;
	}

	void Fire(Vector2 enemyPos)
	{
		if (Time.time - reloaded > 1)
		{
			reloaded = Time.time;
			//var bullet = (GameObject)Instantiate(bulletPref, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
			var bullet = (GameObject)Instantiate(bulletPref, transform.position, transform.rotation);
			bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(5 * (enemyPos.x - bullet.transform.position.x) / Vector2.Distance(enemyPos, bullet.transform.position), 20 * (enemyPos.y - bullet.transform.position.y) / Vector2.Distance(enemyPos, bullet.transform.position));
			Destroy(bullet, 2.0f);
		}
	}
	// Update is called once per frame
	void Update () {
		
		//if (Input.GetMouseButtonDown(0)) {
		//	
		//Debug.Log(Time.time);
		if ((int)(10*Time.time) % 20 == 0) {
			Debug.Log("in");
			waypoints = PathFindingScript.RequestPath (transform.position, enemy.transform.position);
			//waypoints = PathFindingScript.RequestPath (transform.position, new Vector2(0.0f, 4.0f));
			waypointsStack.Clear ();
			foreach (Vector2 point in waypoints) {
				waypointsStack.Push (point);
			}
		}
		Fire (enemy.transform.position);

	//	}
		if (Physics2D.CircleCast (transform.position, 0.3f, enemy.transform.position, Vector2.Distance (transform.position, enemy.transform.position), unwalkableMask)) {
			
		}
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
