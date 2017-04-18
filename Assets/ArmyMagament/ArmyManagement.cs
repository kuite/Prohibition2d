using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.SceneHelpers;

public class ArmyManagement : MonoBehaviour {
	public Sprite SoldierSprite0;
	public Sprite SoldierSprite1;
	public Sprite SoldierSprite2;
	public Sprite SoldierSprite3;
	public Sprite SoldierSprite4;
	public Sprite SoldierSprite5;
	public Sprite SoldierSprite6;
	public Sprite SoldierSprite7;
	public Sprite SoldierSprite8;
	public Sprite DefaultSprite;

	public Image SoldierImageRec;
	public Image SoldierImageMag;

	int currentRecruit = 0;
	int currentManaged = 0;

	List <int> SoldiersRecList;
	List <int> SoldiersMgmtList;

	MemoryHolder Data;

	// Use this for initialization
	void Start () {
		Data = MemoryHolder.GetInstance ();
		SoldiersMgmtList = new List <int> (Data.UserSoldiers.Keys);
		SoldiersRecList = new List <int> (Data.AvailableSoldiers.Keys);
		if(SoldiersRecList.Count > 0)
			SoldierImageRec.sprite = SetSprite (Data.AvailableSoldiers[SoldiersRecList[currentRecruit]].ImageId);
		else
			SoldierImageRec.sprite = DefaultSprite;

		if(SoldiersMgmtList.Count > 0)
			SoldierImageMag.sprite = SetSprite (Data.AvailableSoldiers[SoldiersMgmtList[currentManaged]].ImageId);
		else
			SoldierImageMag.sprite = DefaultSprite;
		//SoldierImageMag = 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hire(){
		if (SoldiersRecList.Count > 0) {
			currentManaged = currentRecruit;
			currentRecruit = 0;
			Data.UserSoldiers.Add (SoldiersRecList [currentManaged], Data.AvailableSoldiers [SoldiersRecList [currentManaged]]);
			SoldiersMgmtList.Add (SoldiersRecList [currentRecruit]);
			Data.AvailableSoldiers.Remove (SoldiersRecList [currentRecruit]);
			SoldiersRecList.Remove (SoldiersRecList [currentRecruit]);
			if (SoldiersRecList.Count > 0)
				SoldierImageRec.sprite = SetSprite (Data.AvailableSoldiers [SoldiersRecList [currentRecruit]].ImageId);
			else
				SoldierImageRec.sprite = DefaultSprite;
			if (SoldiersMgmtList.Count > 0)
				SoldierImageMag.sprite = SetSprite (Data.UserSoldiers [SoldiersMgmtList [SoldiersMgmtList.Count - 1]].ImageId);
			else
				SoldierImageMag.sprite = DefaultSprite;
		}
	}

	public void Fire(){
		if (SoldiersMgmtList.Count > 0) {
			Data.AvailableSoldiers.Add (SoldiersMgmtList [currentManaged], Data.UserSoldiers[SoldiersMgmtList[currentManaged]]);
			SoldiersRecList.Add (SoldiersMgmtList [currentManaged]);

			Data.UserSoldiers.Remove (SoldiersMgmtList [currentManaged]);
			SoldiersMgmtList.Remove (SoldiersMgmtList [currentManaged]);
			if (SoldiersRecList.Count > 0)
				SoldierImageRec.sprite = SetSprite (Data.AvailableSoldiers [SoldiersRecList [SoldiersRecList.Count -1]].ImageId);
			else
				SoldierImageRec.sprite = DefaultSprite;

			if (SoldiersMgmtList.Count > 0)
				SoldierImageMag.sprite = SetSprite (Data.UserSoldiers [SoldiersMgmtList [0]].ImageId);
			else
				SoldierImageMag.sprite = DefaultSprite;
			currentManaged = 0;
		}
	}

	public void SoldierNextPrevMgmt(int upDown){
		currentManaged += upDown;
		if (currentManaged >= SoldiersMgmtList.Count)
			currentManaged = 0;
		else if (currentManaged < 0)
			currentManaged = SoldiersMgmtList.Count - 1;
		SoldierImageMag.sprite = SetSprite (Data.UserSoldiers[SoldiersMgmtList[currentManaged]].ImageId);
	}

	public void SoldierNextPrevRec(int upDown){
		currentRecruit += upDown;
		if (currentRecruit >= SoldiersRecList.Count - 1)
			currentRecruit = 0;
		else if (currentRecruit < 0)
			currentRecruit = SoldiersRecList.Count - 1;
		SoldierImageRec.sprite = SetSprite (Data.AvailableSoldiers[SoldiersRecList[currentRecruit]].ImageId);
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
			case 5:
				return SoldierSprite5;
			case 6:
				return SoldierSprite6;
			case 7:
				return SoldierSprite7;
			case 8:
				return SoldierSprite8;
			default:
				return SoldierSprite0; 
		}
	}
}
