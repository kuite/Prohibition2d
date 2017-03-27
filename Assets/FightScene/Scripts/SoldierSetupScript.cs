
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SceneHelpers;

public class SoldierSetupScript : MonoBehaviour {
	public Vector2 []positionsTeamA;
	public Vector2 []positionsTeamB;
	public GameObject soldierA;
	public GameObject soldierB;
	public GameObject guiAppears;
	public MemoryHolder Data;
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
		foreach (Vector2 pos in positionsTeamB){
			var soldat = (GameObject)Instantiate(soldierB, pos, soldierB.transform.rotation);
		}
		//gui = (GameObject)Instantiate(guiAppears, guiAppears.transform.position, guiAppears.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetMouseButtonDown (1)) {
			Destroy (gui);
		}
		if (Input.GetMouseButtonDown (0)) {
			gui2 = (GameObject)Instantiate(guiAppears, guiAppears.transform.position, guiAppears.transform.rotation);
		}*/
	}
}
