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
		Debug.Log ("comp resources alc: " + Data.computerResources.Alkohol.ToString());
		Debug.Log ("comp resources money: " + Data.computerResources.Money.ToString());
		PubProcess ();
		DistillaryProcess ();
		LocalBusinessProcess ();
		NightClubProcess ();
		CassinoProcess ();
		Debug.Log ("after comp resources alc: " + Data.computerResources.Alkohol.ToString());
		Debug.Log ("after comp resources money: " + Data.computerResources.Money.ToString());
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
		foreach (int i in Data.CompDistricts) {
			int income = 0;
			if (Data.computerResources.Alkohol < 10 * Data.CaschedDistricts [i].Pub.Level) {
				income = Data.computerResources.Alkohol * Data.CaschedDistricts [i].Pub.AlcoholPrice;
				Data.computerResources.Alkohol = 0;
			} else {
				income = Data.CaschedDistricts [i].Pub.Level * Data.CaschedDistricts [i].Pub.AlcoholPrice;
				Data.computerResources.Alkohol -= Data.CaschedDistricts [i].Pub.Level * 10;
			}
			Data.computerResources.Money += income;
		}
	}

	void DistillaryProcess(){
		foreach (int i in Data.UserDistricts) {
			int alc = Data.CaschedDistricts[i].Distillery.Workers * Data.CaschedDistricts[i].Distillery.Level;
			int spendings = (int)((double)Data.CaschedDistricts [i].Distillery.Workers * Data.CaschedDistricts [i].Distillery.WorkerCost);
			Data.playerResources.Alkohol += alc;
			Data.playerResources.Money -= spendings;
		}
		foreach (int i in Data.CompDistricts) {
			int alc = Data.CaschedDistricts[i].Distillery.Workers * Data.CaschedDistricts[i].Distillery.Level;
			int spendings = (int)((double)Data.CaschedDistricts [i].Distillery.Workers * Data.CaschedDistricts [i].Distillery.WorkerCost);
			Data.computerResources.Alkohol += alc;
			Data.computerResources.Money -= spendings;
		}
	}

	void LocalBusinessProcess(){
		foreach (int i in Data.UserDistricts) {
			int income = (int)((double)Data.CaschedDistricts[i].LocalBussines.Level * Data.CaschedDistricts[i].LocalBussines.Tribute * LocalBusinessIncome);
			Data.playerResources.Money += income;
		}
		foreach (int i in Data.CompDistricts) {
			int income = (int)((double)Data.CaschedDistricts[i].LocalBussines.Level * Data.CaschedDistricts[i].LocalBussines.Tribute * LocalBusinessIncome);
			Data.computerResources.Money += income;
		}
	}

	void NightClubProcess(){
		foreach (int i in Data.UserDistricts) {
			int income = Data.CaschedDistricts[i].NightClub.Level * Data.CaschedDistricts[i].NightClub.Girls;
			Data.playerResources.Money += income;
		}
		foreach (int i in Data.CompDistricts) {
			int income = Data.CaschedDistricts[i].NightClub.Level * Data.CaschedDistricts[i].NightClub.Girls;
			Data.computerResources.Money += income;
		}
	}

	void CassinoProcess(){
		int CassinoMoney = 10;
		foreach (int i in Data.UserDistricts) {
			int randomInt = Random.Range (-4 , 5);
			int income = Data.CaschedDistricts[i].Casino.Level * CassinoMoney + randomInt * CasinoSpendings;
			Data.playerResources.Money += income;
		}
		foreach (int i in Data.CompDistricts) {
			int randomInt = Random.Range (-4 , 5);
			int income = Data.CaschedDistricts[i].Casino.Level * CassinoMoney + randomInt * CasinoSpendings;
			Data.computerResources.Money += income;
		}
	}
}
