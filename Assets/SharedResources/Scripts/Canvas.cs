using UnityEngine;
using System;
using System.IO;

namespace Assets.SharedResources.Scripts
{
    public class Canvas : MonoBehaviour {

        // Use this for initialization
        void Start () {
            File.WriteAllText(Path.Combine(Application.persistentDataPath, "Test.txt"), "test file");
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
