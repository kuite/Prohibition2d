
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.SceneHelpers;

public class SoldierSetupScript : MonoBehaviour {
	public Vector2 []positionsTeamA;
	public Vector2 []positionsTeamB;
	public GameObject[] enemies;
	public GameObject[] friends;
	public GameObject soldierA;
	public GameObject soldierB;
	public GameObject guiAppears;
	public MemoryHolder Data;
	public string teamEnemy;
	public string teamFriends;
	//GameObject gui;
	//GameObject gui2;
	// Use this for initialization
	void Start () {
		Data = MemoryHolder.GetInstance ();

		int iterator = 0; //probably has to changed TODO
		foreach (Vector2 pos in positionsTeamA){
			var soldat = (GameObject)Instantiate(soldierA, pos, soldierA.transform.rotation); 
			soldat.SendMessage ("TheStartingInformations", iterator++);	
		}
		iterator = 0;
		foreach (Vector2 pos in positionsTeamB){
			var soldat = (GameObject)Instantiate(soldierB, pos, soldierB.transform.rotation);
			soldat.SendMessage ("TheStartingInformations", iterator++);	
		}
		enemies = GameObject.FindGameObjectsWithTag (teamEnemy);
		friends = GameObject.FindGameObjectsWithTag (teamFriends);
		//gui = (GameObject)Instantiate(guiAppears, guiAppears.transform.position, guiAppears.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if (friends.Length == 0) {
			EndGamebehaviour ();
		}
		if (friends.Length == 0) {
			EndGamebehaviour ();
		}
	}
	void EndGamebehaviour(){
		SceneManager.LoadScene ("EndfightScene");
	}
}
