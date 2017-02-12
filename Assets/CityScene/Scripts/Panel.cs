using System;
using Assets.Model.Context;
using Assets.SharedResources.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CityScene.Scripts
{
    public class Panel : MonoBehaviour {
        public District WorkingDistrict;
        public Text Logger;

        private IContext _context;
        private int population = 0;

        // Use this for initialization
        void Start () {
            var dd = "C:\\projects\\Prohibition2D\\Assets\\SharedResources\\data.s3db";
            _context = new ProhibitionContext(dd);
            WorkingDistrict = new District();
        }
	
        // Update is called once per frame
        void Update () {
            if (WorkingDistrict != null)
            {
                population = WorkingDistrict.Population;
            }

            Logger.text = String.Format("Population {0}", population);
        }

        public void PlusOne()
        {
            WorkingDistrict.PlusOne();
            _context.ExecuteQuery("INSERT INTO Players (Name) VALUES (\'UserCreatedFromUnity\')");
        }
    }
}
