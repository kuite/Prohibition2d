using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SceneHelpers;

public class MapMaker : MonoBehaviour {
	public GameObject districtPrefab;
	public Vector2[] positions;
	MemoryHolder Data;
	public int[] dimentions;
	// Use this for initialization
	void Start () {
		Data = MemoryHolder.GetInstance ();
		int IterId = 1;
		Vector2 DistrictPosition = new Vector2 (0, 0);
		foreach (Vector2 vec in positions) {
			var district = (GameObject)Instantiate (districtPrefab, vec, districtPrefab.transform.rotation);
			district.SendMessage ("SetIdOnCreation", IterId);
			district.SendMessage ("SetPosOnCreation", DistrictPosition);
			IterId++;
			DistrictPosition [0] += 1;
			if (DistrictPosition.x >= dimentions [0]) {
				DistrictPosition.x = 0;
				DistrictPosition.y += 1;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
