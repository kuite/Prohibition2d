using System;
using Assets.SharedResources.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CityScene.Scripts
{
    public class Panel : MonoBehaviour {
        public District WorkingDistrict;

        public Text Logger;

        // Use this for initialization
        void Start () {
            WorkingDistrict = new District();
        }
	
        // Update is called once per frame
        void Update () {
            Logger.text = String.Format("Population {0}", WorkingDistrict.Population.ToString());
        }

        public void PlusOne()
        {
            WorkingDistrict.PlusOne();
        }
    }
}
