using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using Assets.SceneHelpers;
using Assets.Model.PlayableEntities;

public class SoldierScript : MonoBehaviour
{
	public MemoryHolder Data;
	public int SoldierISettingsId = 0;
	SoldierStats soldiersStats;

	private Rigidbody2D rigi;
	private Stack waypointsStack = new Stack ();

	public Vector2 destinationVector;
	private Vector2[] waypoints;
	private Vector2 mousePosition;

	private float reloaded;
	public GameObject bulletPref;
	public GameObject bulletSpawn;
	private GameObject enemy;
	public GameObject[] enemies;
	public Dictionary <int, GameObject> enem;
	public GameObject[] friends;
	public LayerMask unwalkableMask;

	public bool isStereable;
	public bool choosen;

	bool stop = false;
	public string teamEnemy;
	public string teamFriends;
	public bool alive = true;
	float deltaTime = 0.0f;
	int fps = 0;

	// Use this for initialization
	void Start () {
		soldiersStats = new SoldierStats ();
		Data = MemoryHolder.GetInstance ();
		enemies = GameObject.FindGameObjectsWithTag (teamEnemy);
		friends = GameObject.FindGameObjectsWithTag (teamFriends);
		enemy = enemies [0];
		reloaded = Time.time;
		rigi = GetComponent<Rigidbody2D>();
		destinationVector = transform.position;
		choosen = false;

		if (teamFriends == "teamA")
			soldiersStats = Data.UserFightingSoldiers [SoldierISettingsId];
		else {
			if (Data.CompDistricts.Contains (Data.AttackedDistrict)) {
				soldiersStats = Data.EnemyFightingSoldiers [SoldierISettingsId];
			} else {
				soldiersStats = Data.NeutralFightingSoldiers [SoldierISettingsId];
			}
		}
	}

	void OnDestroy(){		
		Debug.Log ("Dead");
	}

	void TheStartingInformations(int m_id){
		Debug.Log ("StartingInformation " + m_id.ToString());
		SoldierISettingsId = m_id;
	}

	void Fire(Vector2 enemyPos)
	{
		float recoil = 0.2f + (rigi.velocity.magnitude / soldiersStats.Aim);
		enemyPos += new Vector2(Random.Range (-recoil, recoil), Random.Range (-recoil, recoil));
		if (Time.time - reloaded > 0.5f)
		{
			float bulletSpeed = 8.0f;
			reloaded = Time.time;
			//var bullet = (GameObject)Instantiate(bulletPref, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
			var bullet = (GameObject)Instantiate(bulletPref, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
			bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * (enemyPos.x - bullet.transform.position.x) / Vector2.Distance(enemyPos, bullet.transform.position), bulletSpeed * (enemyPos.y - bullet.transform.position.y) / Vector2.Distance(enemyPos, bullet.transform.position));
			Destroy(bullet, 2.0f);
		}
	}
	// Update is called once per frame
	void Update () {
		if ((enemies.Length == 0)) {
			EndGamebehaviour (teamFriends);
		}
		else if (alive) {
			enemies = GameObject.FindGameObjectsWithTag (teamEnemy);
			if (!isStereable) {
				BehaviourOne ();
			} else {
				BehaviourTwo ();
			}
			if (soldiersStats.Hp <= 0) {
				if (teamFriends == "teamA") {
					Debug.Log ("teamA REmoved" + (SoldierISettingsId.ToString()));
					Data.UserSoldiers.Remove (SoldierISettingsId);
				} else {
					Debug.Log ("teamB REmoved" + (SoldierISettingsId.ToString()));
					if (Data.CompDistricts.Contains (Data.AttackedDistrict)) {
						Data.CompSoldiers.Remove (SoldierISettingsId);
					} else {
						Data.NeutralSoldiers.Remove (SoldierISettingsId);
					}
				}
				alive = false;
			}
			SquareChoice ();
		} else {
			Destroy (gameObject);
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
			float approachSpeed = (float)soldiersStats.Speed *0.3f;
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
			if (pretender.Length < closest.Length || enemy == null) {
				closest = pretender;
				enemy = en;
			}
		}
		return closest;
	}

	bool stopAndShoot(){
		if (enemy != null) {
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
		}
			stop = false;
			return false;
	}

	void runAndShoot(){
		foreach (GameObject enemyIterator in enemies) {
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
		foreach (Vector2 point in waypoints) {
			waypointsStack.Push (point);
		}
	}

	void fpsCounter(){
		deltaTime += Time.deltaTime;
		if ( deltaTime> 1.0f) {
			//Debug.Log (fps);
			fps = 0;
			deltaTime = Time.deltaTime;
		}
		fps++;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "bullet") {
			soldiersStats.Hp -= 1;
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
		if(enemy!=null)
			lookAtXY (enemy.transform.position.x, enemy.transform.position.y);
		FollowWaypoints ();
	}

	void SquareChoice(){
		if (isStereable) {
			if (Input.GetMouseButtonDown (0)) {
				var v3 = Input.mousePosition;
				v3.z = 10.0f;
				v3 = Camera.main.ScreenToWorldPoint (v3);
				choosen = false;
				mousePosition = new Vector2 (v3.x, v3.y);
			}
			if (Input.GetMouseButton (0)) {
				Vector3 v3 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				DrawLine (new Vector3 (mousePosition.x, mousePosition.y, 0), new Vector3(mousePosition.x, v3.y, 0), Color.gray, 0.015f);	
				DrawLine (new Vector3 (mousePosition.x, mousePosition.y, 0), new Vector3(v3.x, mousePosition.y, 0), Color.gray, 0.015f);	
				DrawLine (new Vector3 (v3.x, v3.y, 0), new Vector3(v3.x, mousePosition.y, 0), Color.gray, 0.015f);	
				DrawLine (new Vector3 (v3.x, v3.y, 0), new Vector3(mousePosition.x, v3.y, 0), Color.gray, 0.015f);	
			}
			if (Input.GetMouseButtonUp (0)) {
				Vector2 clickPosition = new Vector2 (0, 0);
				var v3 = Input.mousePosition;
				v3.z = 10.0f;
				v3 = Camera.main.ScreenToWorldPoint (v3);
				clickPosition = new Vector2 (v3.x, v3.y);
				if ((transform.position.x < clickPosition.x && transform.position.x > mousePosition.x) || (transform.position.x > clickPosition.x && transform.position.x < mousePosition.x)) {
					if ((transform.position.y < clickPosition.y && transform.position.y > mousePosition.y) || (transform.position.y > clickPosition.y && transform.position.y < mousePosition.y)) {
						choosen = true;
					}
				}
			}
		}
	}

	void BehaviourTwo(){//stered by user
		Vector2 clickPosition = new Vector2(0,0) ;
		if (choosen && Input.GetMouseButtonDown (1)) {
			var v3 = Input.mousePosition;
			v3.z = 10.0f;
			v3 = Camera.main.ScreenToWorldPoint (v3);

			clickPosition = new Vector2 (v3.x, v3.y);
			waypoints = PathFindingScript.RequestPath (transform.position, clickPosition);

			fillWaypointsStack (clickPosition);
		}
		FindEnemy ();
		runAndShoot ();
	    lookAtXY (enemy.transform.position.x, enemy.transform.position.y);
		FollowWaypoints ();

	}

	void EndGamebehaviour(string winner){
		Data.Winner = winner;
		SceneManager.LoadScene ("EndfightScene");
	}

	void FindEnemy(){
		foreach (GameObject enemyIterator in enemies) {
			enemy = enemyIterator;
			break;
		}
	}

	void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
	{
		GameObject myLine = new GameObject();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.SetColors(color, color);
		lr.SetWidth(0.1f, 0.1f);
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
		GameObject.Destroy(myLine, duration);
	}
}

