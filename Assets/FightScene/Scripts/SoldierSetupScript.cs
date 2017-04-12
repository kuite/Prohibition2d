
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.SceneHelpers;
using Assets.Model.PlayableEntities;

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
		int iter = 0;
		foreach (KeyValuePair<int, SoldierStats> entry in Data.UserFightingSoldiers) {
			var soldat = (GameObject)Instantiate(soldierA, positionsTeamA[iter], soldierA.transform.rotation); 
			soldat.SendMessage ("TheStartingInformations", entry.Key);	
			iter++;
			if (iter == positionsTeamA.Length)
				break;
		}
		iter = 0;
		foreach (KeyValuePair<int, SoldierStats> obj in Data.EnemyFightingSoldiers) {
			var soldat = (GameObject)Instantiate(soldierB, positionsTeamB[iter], soldierB.transform.rotation); 
			soldat.SendMessage ("TheStartingInformations", obj.Key);	
			iter++;
			if (iter == positionsTeamB.Length)
				break;
		}
		/*
		foreach (Vector2 pos in positionsTeamB){
			var soldat = (GameObject)Instantiate(soldierB, pos, soldierB.transform.rotation);
			soldat.SendMessage ("TheStartingInformations", iterator++);	
		}*/
		//enemies = GameObject.FindGameObjectsWithTag (teamEnemy);
		//friends = GameObject.FindGameObjectsWithTag (teamFriends);
		//gui = (GameObject)Instantiate(guiAppears, guiAppears.transform.position, guiAppears.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (friends.Length == 0) {
			EndGamebehaviour ();
		}
		if (friends.Length == 0) {
			EndGamebehaviour ();
		}*/
	}
	void EndGamebehaviour(){
		SceneManager.LoadScene ("EndfightScene");
	}
}
