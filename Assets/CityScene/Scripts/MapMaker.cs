using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SceneHelpers;

public class MapMaker : MonoBehaviour {
	public GameObject districtPrefab;
	public Vector2[] positions;
	MemoryHolder Data;
	// Use this for initialization
	void Start () {
		Data = MemoryHolder.GetInstance ();
		int IterId = 1;
		foreach (Vector2 vec in positions) {
			var district = (GameObject)Instantiate (districtPrefab, vec, districtPrefab.transform.rotation);
			district.SendMessage ("SetIdOnCreation", IterId);
			IterId++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
