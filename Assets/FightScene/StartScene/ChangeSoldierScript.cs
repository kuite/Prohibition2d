using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	int SpriteNumber;
	int SpriteNumber1;
	int SpriteNumber2;

	int choice;

	// Use this for initialization
	void Start () {
		SpriteNumber = 0;
     	SpriteNumber1 = 0;
		SpriteNumber2 = 0;

		Soldier1Image.sprite = SoldierSprite0;
     	Soldier2Image.sprite = SoldierSprite1;
     	Soldier3Image.sprite = SoldierSprite2;

		Soldiers.Add (0);
		Soldiers.Add (1);
		Soldiers.Add (2);
		Soldiers.Add (3);
		Soldiers.Add (4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeOnButton1(int upOrDown){
		SpriteNumber += upOrDown;
		if (SpriteNumber < 0)
			SpriteNumber = Soldiers.Count;
		else if (SpriteNumber >= Soldiers.Count)
			SpriteNumber = 0;
		switch (SpriteNumber) {
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
			SpriteNumber1 = Soldiers.Count;
		else if (SpriteNumber1 >= Soldiers.Count)
			SpriteNumber1 = 0;
		
		switch (SpriteNumber1) {
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
			SpriteNumber2 = Soldiers.Count;
		else if (SpriteNumber2 >= Soldiers.Count)
			SpriteNumber2 = 0;
		
		switch (SpriteNumber2) {
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
}
