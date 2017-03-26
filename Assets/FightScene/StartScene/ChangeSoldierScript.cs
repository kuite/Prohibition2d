using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.CityScene.Scripts;

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

	DataScript Data;

	int SpriteNumber;
	int SpriteNumber1;
	int SpriteNumber2;

	int choice;

	// Use this for initialization
	void Start () {
		Data = DataScript.GetInstance ();

		SpriteNumber = 0;
     	SpriteNumber1 = 0;
		SpriteNumber2 = 0;

		Soldier1Image.sprite = SoldierSprite0;
     	Soldier2Image.sprite = SoldierSprite1;
     	Soldier3Image.sprite = SoldierSprite2;
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
		switch (Data.UserSoldiers[SpriteNumber].ImageId) {
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
	}

	public void ChangeOnButton2(int upOrDown){
		SpriteNumber1 += upOrDown;
		if (SpriteNumber1 < 0)
			SpriteNumber1 = Data.UserSoldiers.Count;
		else if (SpriteNumber1 >= Data.UserSoldiers.Count)
			SpriteNumber1 = 0;
		
		switch (Data.UserSoldiers[SpriteNumber1].ImageId) {
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
	}

	public void ChangeOnButton3(int upOrDown){
		SpriteNumber2 += upOrDown;
		if (SpriteNumber2 < 0)
			SpriteNumber2 = Data.UserSoldiers.Count;
		else if (SpriteNumber2 >= Data.UserSoldiers.Count)
			SpriteNumber2 = 0;
		
		switch (Data.UserSoldiers[SpriteNumber2].ImageId) {
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
	}

	public void LetTheBodyHitTheFloor(){
		SceneManager.LoadScene ("FightScene");
	}
}
