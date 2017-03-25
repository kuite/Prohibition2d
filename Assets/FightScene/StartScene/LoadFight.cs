using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.FightScene.StartScene
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