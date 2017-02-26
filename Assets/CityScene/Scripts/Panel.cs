using System;
using System.Collections.Generic;
using Assets.Model.Buildings;
using Assets.Model.Context;
using Assets.Model.Repositories;
using Assets.SharedResources.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CityScene.Scripts
{
    public class Panel : MonoBehaviour
    {
        public District WorkingDistrict;
        public Text Logger;
        public DetailsPanel DetailsPanel;

        private IRepository<DistrictSettings> _districtRepository;
        private SqliteContext _context;

        // Use this for initialization
        private void Start ()
        {
            _context = new SqliteContext("C:\\projects\\Prohibition2D\\Assets\\SharedResources\\data.s3db");
            _districtRepository = new DistrictRepository(_context);
            WorkingDistrict = new District(_context);
        }
	
        // Update is called once per frame
        private void Update ()
        {
            if (WorkingDistrict != null)
            {

            }

            Logger.text = String.Format("Population {0}", 777);
        }

//        public void UpgradeAttribute()
//        {
//            IEnumerable<DistrictSettings> dadad = _districtRepository.GetAll();
//            //WorkingDistrict.UpgradeAttribute();
//            //_context.ExecuteQuery("INSERT INTO Players (Name) VALUES (\'UserCreatedFromUnity\')");
//        }

        public void CasioDetailsButton()
        {
            DetailsPanel = new DetailsPanel(WorkingDistrict.Casino);
        }
    }
}
