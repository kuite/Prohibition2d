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

		// Use this for initialization		
		// Update is called once per frame
		void Update () {
		}
			

		public void LodaThatFight(){
			SceneManager.LoadSceneAsync ("FightScene");
		}
	}
}