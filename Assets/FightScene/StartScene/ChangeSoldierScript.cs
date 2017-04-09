using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.CityScene.Scripts;
using Assets.SceneHelpers;
using Assets.Model.PlayableEntities;

public class ChangeSoldierScript : MonoBehaviour {
	List <int> Soldiers = new List<int>();
	public Image Soldier1Image;
	public Image Soldier2Image;
	public Image Soldier3Image;

	public Sprite SoldierSprite0;
	public Sprite SoldierSprite1;
	public Sprite SoldierSprite2;
	public Sprite SoldierSprite3;
	public Sprite SoldierSprite4;

	MemoryHolder Data;

	public int SpriteNumber;
	public int SpriteNumber1;
	public int SpriteNumber2;

	List <int> SoldiersList;

	int choice;

	public Text p1hp;
	public Text p2hp;
	public Text p3hp;

	public Text p1aim;
	public Text p2aim;
	public Text p3aim;

	public Text p1spd;
	public Text p2spd;
	public Text p3spd;

	public Text p1wpn;
	public Text p2wpn;
	public Text p3wpn;

	// Use this for initialization
	void Start () {
		Data = MemoryHolder.GetInstance ();
		Data.UserFightingSoldiers.Clear ();

		SoldiersList = new List <int> (Data.UserSoldiers.Keys);

		SpriteNumber = 0;
     	SpriteNumber1 = 1;
		SpriteNumber2 = 2;

		Soldier1Image.sprite = SetSprite(Data.UserSoldiers[SoldiersList[SpriteNumber]].ImageId);
		Soldier2Image.sprite = SetSprite(Data.UserSoldiers[SoldiersList[SpriteNumber1]].ImageId);
		Soldier3Image.sprite = SetSprite(Data.UserSoldiers[SoldiersList[SpriteNumber2]].ImageId);

		p1aim.text = Data.UserSoldiers [SoldiersList [SpriteNumber]].Aim.ToString ();
		p1wpn.text = Data.UserSoldiers [SoldiersList [SpriteNumber]].WeaponSkill.ToString ();
		p1spd.text = Data.UserSoldiers [SoldiersList [SpriteNumber]].Speed.ToString ();
		p1hp.text = Data.UserSoldiers [SoldiersList [SpriteNumber]].Hp.ToString ();

		p2aim.text = Data.UserSoldiers [SoldiersList [SpriteNumber1]].Aim.ToString ();
		p2wpn.text = Data.UserSoldiers [SoldiersList [SpriteNumber1]].WeaponSkill.ToString ();
		p2spd.text = Data.UserSoldiers [SoldiersList [SpriteNumber1]].Speed.ToString ();
		p2hp.text = Data.UserSoldiers [SoldiersList [SpriteNumber1]].Hp.ToString ();

		p3aim.text = Data.UserSoldiers [SoldiersList [SpriteNumber2]].Aim.ToString ();
		p3wpn.text = Data.UserSoldiers [SoldiersList [SpriteNumber2]].WeaponSkill.ToString ();
		p3spd.text = Data.UserSoldiers [SoldiersList [SpriteNumber2]].Speed.ToString ();
		p3hp.text = Data.UserSoldiers [SoldiersList [SpriteNumber2]].Hp.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeOnButton1(int upOrDown){
		SpriteNumber += upOrDown;
		if (SpriteNumber < 0)
			SpriteNumber = Data.UserSoldiers.Count;
		else if (SpriteNumber >= Data.UserSoldiers.Count)
			SpriteNumber = 0;
		
		SpriteNumber = checkIfUsed (upOrDown,SpriteNumber);
		SpriteNumber = checkIfUsed (upOrDown,SpriteNumber);

		switch (Data.UserSoldiers[SoldiersList[SpriteNumber]].ImageId) {
		case 0:
			Soldier1Image.sprite = SoldierSprite0;			
			break;
		case 1:
			Soldier1Image.sprite = SoldierSprite1;
			break;
		case 2:
			Soldier1Image.sprite = SoldierSprite2;
			break;
		case 3:
			Soldier1Image.sprite = SoldierSprite3;
			break;
		case 4:
			Soldier1Image.sprite = SoldierSprite4;
			break;
		}
		p1aim.text = Data.UserSoldiers [SoldiersList [SpriteNumber]].Aim.ToString ();
		p1wpn.text = Data.UserSoldiers [SoldiersList [SpriteNumber]].WeaponSkill.ToString ();
		p1spd.text = Data.UserSoldiers [SoldiersList [SpriteNumber]].Speed.ToString ();
		p1hp.text = Data.UserSoldiers [SoldiersList [SpriteNumber]].Hp.ToString ();
	}

	public void ChangeOnButton2(int upOrDown){
		if (Data.UserSoldiers.Count > 1) {
			SpriteNumber1 += upOrDown;
			if (SpriteNumber1 < 0)
				SpriteNumber1 = Data.UserSoldiers.Count;
			else if (SpriteNumber1 >= Data.UserSoldiers.Count)
				SpriteNumber1 = 0;
		
			SpriteNumber1 = checkIfUsed (upOrDown, SpriteNumber1);
			SpriteNumber1 = checkIfUsed (upOrDown, SpriteNumber1);

			switch (Data.UserSoldiers [SoldiersList [SpriteNumber1]].ImageId) {
			case 0:
				Soldier2Image.sprite = SoldierSprite0;			
				break;
			case 1:
				Soldier2Image.sprite = SoldierSprite1;
				break;
			case 2:
				Soldier2Image.sprite = SoldierSprite2;
				break;
			case 3:
				Soldier2Image.sprite = SoldierSprite3;
				break;
			case 4:
				Soldier2Image.sprite = SoldierSprite4;
				break;
			}

			p2aim.text = Data.UserSoldiers [SoldiersList [SpriteNumber1]].Aim.ToString ();
			p2wpn.text = Data.UserSoldiers [SoldiersList [SpriteNumber1]].WeaponSkill.ToString ();
			p2spd.text = Data.UserSoldiers [SoldiersList [SpriteNumber1]].Speed.ToString ();
			p2hp.text = Data.UserSoldiers [SoldiersList [SpriteNumber1]].Hp.ToString ();
		}
	}

	public void ChangeOnButton3(int upOrDown){
		if (Data.UserSoldiers.Count > 2) {
			SpriteNumber2 += upOrDown;
			if (SpriteNumber2 < 0)
				SpriteNumber2 = Data.UserSoldiers.Count - 1;
			else if (SpriteNumber2 >= Data.UserSoldiers.Count)//TOCHECK
			SpriteNumber2 = 0;
			SpriteNumber2 = checkIfUsed (upOrDown, SpriteNumber2);
			SpriteNumber2 = checkIfUsed (upOrDown, SpriteNumber2);

			switch (Data.UserSoldiers [SoldiersList [SpriteNumber2]].ImageId) {
			case 0:
				Soldier3Image.sprite = SoldierSprite0;			
				break;
			case 1:
				Soldier3Image.sprite = SoldierSprite1;
				break;
			case 2:
				Soldier3Image.sprite = SoldierSprite2;
				break;
			case 3:
				Soldier3Image.sprite = SoldierSprite3;
				break;
			case 4:
				Soldier3Image.sprite = SoldierSprite4;
				break;
			}

			p3aim.text = Data.UserSoldiers [SoldiersList [SpriteNumber2]].Aim.ToString ();
			p3wpn.text = Data.UserSoldiers [SoldiersList [SpriteNumber2]].WeaponSkill.ToString ();
			p3spd.text = Data.UserSoldiers [SoldiersList [SpriteNumber2]].Speed.ToString ();
			p3hp.text = Data.UserSoldiers [SoldiersList [SpriteNumber2]].Hp.ToString ();
		}
	}

	void PrintStats(SoldierStats stats){
		Debug.Log ("Aim: ");
		Debug.Log (stats.Aim);
		Debug.Log ("Hp: ");
		Debug.Log (stats.Hp);
	}

	int checkIfUsed(int upOrDown, int number){
		Debug.Log ("S1, S2, S3, number");
		Debug.Log (SpriteNumber);
		Debug.Log (SpriteNumber1);
		Debug.Log (SpriteNumber2);
		Debug.Log (number);
		Debug.Log (Data.UserSoldiers.Values.Count);
		//if ((((number == SpriteNumber) && (number == SpriteNumber1)) || ((number == SpriteNumber) && (number == SpriteNumber2))) || ((number == SpriteNumber1) && (number == SpriteNumber2))) {
		if ((SpriteNumber == SpriteNumber1) || (SpriteNumber == SpriteNumber2) || (SpriteNumber1 == SpriteNumber2)) {
			if (upOrDown == -1) {
				number -= 1;
				if (number < 0)
					number = Data.UserSoldiers.Values.Count - 1;
			} else {
				number += 1;
				if (number >= Data.UserSoldiers.Values.Count)
					number = 0;
			}
		}
		return number;
	}

	Sprite SetSprite(int sprNumber){
		switch (sprNumber) {
			case 0:
				return SoldierSprite0;			
			case 1:
				return SoldierSprite1;
			case 2:
				return SoldierSprite2;
			case 3:
				return SoldierSprite3;
			case 4:
				return SoldierSprite4;
			default:
				return SoldierSprite0; 
		}
	}

	public void LetTheBodyHitTheFloor(){
		Data.UserFightingSoldiers.Add (SoldiersList [SpriteNumber], Data.UserSoldiers[SoldiersList [SpriteNumber]]);
		Data.UserFightingSoldiers.Add (SoldiersList [SpriteNumber1], Data.UserSoldiers[SoldiersList [SpriteNumber1]]);
		Data.UserFightingSoldiers.Add (SoldiersList [SpriteNumber2], Data.UserSoldiers[SoldiersList [SpriteNumber2]]);

		Data.EnemyFightingSoldiers.Add(4, Data.UserSoldiers[4]);
		Data.EnemyFightingSoldiers.Add(5, Data.UserSoldiers[5]);
		Data.EnemyFightingSoldiers.Add(6, Data.UserSoldiers[6]);

		SceneManager.LoadScene ("FightScene");
	}
}
