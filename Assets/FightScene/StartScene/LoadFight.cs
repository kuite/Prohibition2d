using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Model.Buildings;
using Assets.Model.Context;
using UnityEngine;

namespace Assets.CityScene.Scripts
{
	public class LoadFight : MonoBehaviour {

		public Panel Panel;
		bool created = false;
		public static LoadFight instance;
		long variable = 0;

		// Use this for initialization		
		// Update is called once per frame
		void Update () {
			variable +=1;
			Debug.Log (variable);
			if (Input.GetMouseButtonDown (0)) {
				//SceneManager.LoadSceneAsync ("FightScene");
			}
		}

		public void Awake() {
			if (instance == null) {
				instance = this;
				DontDestroyOnLoad (transform.gameObject);
			}
			else {
				Destroy (this.gameObject);
				return;
			}
		}

		public void LodaThatFight(){
			SceneManager.LoadSceneAsync ("FightScene");
		}
	}
}