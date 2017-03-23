using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataScript : MonoBehaviour {

	static DataScript instance;

	int variable1;
	int variable2;

	// Use this for initialization
	void Start () {
		if (instance != null) {		//if theere is another instance (singleton check
			Destroy(this.gameObject);
			return;
		}

		instance = this;
		GameObject.DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
