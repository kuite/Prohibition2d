using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.SceneHelpers;

public class LoadCityScene : MonoBehaviour {
	MemoryHolder Data;
	// Use this for initialization
	void Start () {
		Data = MemoryHolder.GetInstance ();
		Debug.Log ("team that take district " + Data.Winner);
		Debug.Log ("User has this District already : " + Data.UserDistricts.Contains (Data.AttackedDistrict).ToString());
		if (Data.Winner == "teamA" && !Data.UserDistricts.Contains (Data.AttackedDistrict)) {
			Data.UserDistricts.Add (Data.AttackedDistrict);
			Data.CompDistricts.Remove (Data.AttackedDistrict);
			Debug.Log ("User has the Dist");
		} else if (Data.Winner == "teamB" && !Data.CompDistricts.Contains (Data.AttackedDistrict)) {
			Data.CompDistricts.Add (Data.AttackedDistrict);
			Data.UserDistricts.Remove (Data.AttackedDistrict);
			Debug.Log ("Comp has the Dist");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene ("CityScene");
		}

	}
}
