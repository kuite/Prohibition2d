using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SceneHelpers;

public class ComputerEconomyAI : MonoBehaviour {
	MemoryHolder Data;
	private int Money;
	private int Alkohol;
	//AgressionLevel will be used to detrmine how agressive will be computers economy decisions;
	//for egzample high agression will imply that computer will rize the percent of Tribute to gain extra start money,
	//then invest in army and attack nearest district, lower level of agression will affect in slow pase economy build up 
	//investing in levels of buildings and distillaries
	private int AgressionLevel;

	// Use this for initialization
	void Start () {
		Data = MemoryHolder.GetInstance ();
		Money = Data.computerResources.Money;
		Alkohol = Data.computerResources.Alkohol;
		AgressionLevel = 2;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DistrictsDecisions(){
		foreach (int i in Data.CompDistricts) {
			Data.CaschedDistricts [i];	
			switch (AgressionLevel) {
			case 0:
				Debug.Log ("AgresionLevel = 0");
			}
		}
	}
}
