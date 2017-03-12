
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSetupScript : MonoBehaviour {
	public Vector2 []positionsTeamA;
	public Vector2 []positionsTeamB;
	public GameObject soldierA;
	public GameObject soldierB;
	public GameObject guiAppears;
	//GameObject gui;
	//GameObject gui2;
	// Use this for initialization
	void Start () {
		foreach (Vector2 pos in positionsTeamA){
			var soldat = (GameObject)Instantiate(soldierA, pos, soldierA.transform.rotation);
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
