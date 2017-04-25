using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SceneHelpers;
using UnityEngine.SceneManagement;

public class EndRoundScript : MonoBehaviour {

	MemoryHolder Data;
	//todo change locla business input to some changing value
	int LocalBusinessIncome;
	int CasinoSpendings;
	// Use this for initialization
	void Start () {
		Debug.Log ("Start THe END");
		Data = MemoryHolder.GetInstance ();
		LocalBusinessIncome = 100;
		CasinoSpendings = 100;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void ProcessTheRound(){
		Debug.Log ("dziala");
		PubProcess ();
		DistillaryProcess ();
		LocalBusinessProcess ();
		NightClubProcess ();
		CassinoProcess ();
		SceneManager.LoadScene ("CityScene");
	}

	void PubProcess(){
		foreach (int i in Data.UserDistricts) {
			int income = 0;
			if (Data.playerResources.Alkohol < 10 * Data.CaschedDistricts [i].Pub.Level) {
				income = Data.playerResources.Alkohol * Data.CaschedDistricts [i].Pub.AlcoholPrice;
				Data.playerResources.Alkohol = 0;
			} else {
				income = Data.CaschedDistricts [i].Pub.Level * Data.CaschedDistricts [i].Pub.AlcoholPrice;
				Data.playerResources.Alkohol -= Data.CaschedDistricts [i].Pub.Level * 10;
			}
			Data.playerResources.Money += income;
		}
	}

	void DistillaryProcess(){
		foreach (int i in Data.UserDistricts) {
			int alc = Data.CaschedDistricts[i].Distillery.Workers * Data.CaschedDistricts[i].Distillery.Level;
			int spendings = (int)((double)Data.CaschedDistricts [i].Distillery.Workers * Data.CaschedDistricts [i].Distillery.WorkerCost);
			Data.playerResources.Alkohol += alc;
			Data.playerResources.Money -= spendings;
		}
	}

	void LocalBusinessProcess(){
		foreach (int i in Data.UserDistricts) {
			int income = (int)((double)Data.CaschedDistricts[i].LocalBussines.Level * Data.CaschedDistricts[i].LocalBussines.Tribute * LocalBusinessIncome);
			Data.playerResources.Money += income;
		}
	}

	void NightClubProcess(){
		foreach (int i in Data.UserDistricts) {
			int income = Data.CaschedDistricts[i].NightClub.Level * Data.CaschedDistricts[i].NightClub.Girls;
			Data.playerResources.Money += income;
		}
	}

	void CassinoProcess(){
		foreach (int i in Data.UserDistricts) {
			int randomInt = Random.Range (-4 , 5);
			int income = Data.CaschedDistricts[i].Casino.Level * 100 + randomInt * CasinoSpendings;
			Data.playerResources.Money += income;
		}
	}
}
