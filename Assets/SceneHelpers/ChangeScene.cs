using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.SceneHelpers
{
    public class ChangeScene : MonoBehaviour {
        public string sceneName;

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }

        public void ChangeSceneToString(string sceneName){
            SceneManager.LoadScene (sceneName);
        }
    }
}
