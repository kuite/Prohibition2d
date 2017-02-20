using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoldierScript : MonoBehaviour {
	private Rigidbody2D rigi;
	private Stack waypointsStack = new Stack ();
	public Vector2 destinationVector;
	private Vector2[] waypoints;
	private float reloaded;
	public GameObject bulletPref;
	public GameObject bulletSpawn;
	private GameObject enemy;
	public GameObject[] enemies;
	public LayerMask unwalkableMask;
	public bool isStereable;
	private int hp = 100;
	bool stop = false;
	public string teamEnemy;
	public bool alive = true;
	float deltaTime = 0.0f;
	int fps = 0;
	// Use this for initialization
	void Start () {
		enemies = GameObject.FindGameObjectsWithTag (teamEnemy);
		enemy = enemies [0];
		reloaded = Time.time;
		rigi = GetComponent<Rigidbody2D>();
		destinationVector = transform.position;
	}

	void Fire(Vector2 enemyPos)
	{
		if (Time.time - reloaded > 0.5f)
		{
			float bulletSpeed = 5.0f;
			reloaded = Time.time;
			//var bullet = (GameObject)Instantiate(bulletPref, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
			var bullet = (GameObject)Instantiate(bulletPref, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
			bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * (enemyPos.x - bullet.transform.position.x) / Vector2.Distance(enemyPos, bullet.transform.position), bulletSpeed * (enemyPos.y - bullet.transform.position.y) / Vector2.Distance(enemyPos, bullet.transform.position));
			Destroy(bullet, 2.0f);
		}
	}
	// Update is called once per frame
	void Update () {
		if (!isStereable) {
			BehaviourOne ();
		}
		else {
			BehaviourTwo ();
		}
		fpsCounter ();
		if (hp <= 0) {
			alive = false;
		}
	}


	private void lookAtXY(float x, float y)
	{
		Vector3 targetDir = new Vector3(x, y, 0) - transform.position;
		float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, 0.6f);
	}

	private bool Approach(Vector2 wayP)//float x, float y)
	{
		if (!stop) {
			float approachSpeed = 1.5f;
			Vector2 approachDestination = new Vector2 (wayP.x, wayP.y);
			Vector2 myPoss = rigi.position;

			if (Vector2.Distance (approachDestination, myPoss) < 0.2f) {
				rigi.velocity = new Vector2 (0f, 0f);
				return true;
			}
			rigi.velocity = new Vector2 (approachSpeed * (approachDestination.x - myPoss.x) / Vector2.Distance (approachDestination, myPoss), approachSpeed * (approachDestination.y - myPoss.y) / Vector2.Distance (approachDestination, myPoss));
			return false;
		} else {
			rigi.velocity = new Vector2 (0.0f, 0.0f);
			return false;
		}
	}

	void FollowWaypoints(){
		if (Approach (destinationVector) && waypointsStack.Count > 0) {
			destinationVector = (Vector2)waypointsStack.Pop ();
		}
	}

	Vector2[] FindClosest(){
		Vector2 []closest = PathFindingScript.RequestPath (transform.position, enemies[0].transform.position);
		Vector2	[]pretender;
		foreach(GameObject en in enemies){
			if (en == null)
				continue;
			pretender = PathFindingScript.RequestPath (transform.position, en.transform.position);
			if (pretender.Length < closest.Length) {
				closest = pretender;
				enemy = en;
			}
		}
		return closest;
	}

	bool stopAndShoot(){
		int enemyInRange = 0;
		Vector3 directionToTarget = (enemy.transform.position - transform.position).normalized; 
		if (Physics2D.CircleCast (transform.position, 0.05f, directionToTarget, Vector2.Distance (transform.position, enemy.transform.position), unwalkableMask)) {
			foreach (GameObject enemyIterator in enemies) {
				directionToTarget = (enemyIterator.transform.position - transform.position).normalized; 
				if (!Physics2D.CircleCast (transform.position, 0.05f, directionToTarget, Vector2.Distance (transform.position, enemyIterator.transform.position), unwalkableMask)) {
					enemyInRange++;
					Fire (enemyIterator.transform.position);
					enemy = enemyIterator;
					break;
				}
			}
			if (enemyInRange > 0) {
				stop = true;
				return true;
			}
		} else {
			Fire (enemy.transform.position);
			stop = true;
			return true;
		}
		stop = false;
		return false;
	}

	void runAndShoot(){
		foreach (GameObject enemyIterator in enemies) {
			//Vector3 directionToTarget = new Vector3 (0, 0, 0);
			Vector3 directionToTarget = (enemyIterator.transform.position - transform.position).normalized; 
			if (!Physics2D.CircleCast (transform.position, 0.05f, directionToTarget, Vector2.Distance (transform.position, enemyIterator.transform.position), unwalkableMask)) {
				Fire (enemyIterator.transform.position);
				enemy = enemyIterator;
				break;
			}
		}
	}

	void fillWaypointsStack(Vector2 lastPosition){
		waypointsStack.Clear ();
		if(isStereable)
			waypointsStack.Push (lastPosition);
		foreach (Vector2 point in waypoints) {
			waypointsStack.Push (point);
		}
	}

	void fpsCounter(){
		deltaTime += Time.deltaTime;
		if ( deltaTime> 1.0f) {
			Debug.Log (fps);
			fps = 0;
			deltaTime = Time.deltaTime;
		}
		fps++;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "bullet") {
			hp -= 50;
		}
	}
		
	void runAway(){
		Vector2 runningDirrection = new Vector2(0.0f, 0.0f);
		int numOfEnemies = 0;
		foreach (GameObject enemyIterator in enemies) {
		//	runningDirrection += enemyIterator.transform.position;
			numOfEnemies++;
		}
		runningDirrection /= numOfEnemies;
	}

	void BehaviourOne(){//go to closest enemies and shoot closest oponent in range
		if ( !stopAndShoot() && (int)(10 * Time.time) % 15 == 0) {
			waypoints = FindClosest ();
			fillWaypointsStack (new Vector2(0,0));
		}
		lookAtXY (enemy.transform.position.x, enemy.transform.position.y);
		FollowWaypoints ();
	}

	void BehaviourTwo(){//stered by user
		Vector2 clickPosition = new Vector2(0,0) ;
		if (Input.GetMouseButtonDown (0)) {
			var v3 = Input.mousePosition;
			v3.z = 10.0f;
			v3 = Camera.main.ScreenToWorldPoint (v3);

			clickPosition = new Vector2 (v3.x, v3.y);
			Debug.Log (clickPosition);
			waypoints = PathFindingScript.RequestPath (transform.position, clickPosition);

			fillWaypointsStack (clickPosition);
		}
		runAndShoot ();

		lookAtXY (enemy.transform.position.x, enemy.transform.position.y);
		FollowWaypoints ();

	}
}
