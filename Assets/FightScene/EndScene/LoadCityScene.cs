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
		if (Data.Winner == "teamA" && !Data.UserDistricts.Contains (Data.AttackedDistrict)) {
			Data.UserDistricts.Add (Data.AttackedDistrict);
		}
		else if(!Data.CompDistricts.Contains(Data.AttackedDistrict))
			Data.CompDistricts.Add(Data.AttackedDistrict);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene ("CityScene");
		}

	}
}
