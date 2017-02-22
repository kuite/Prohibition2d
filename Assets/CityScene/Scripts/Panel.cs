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

        private IRepository<DistrictSettings> _districtRepository;
        private SqliteContext _context;
        private int _population = 0;

        // Use this for initialization
        private void Start ()
        {
            _context = new SqliteContext("C:\\projects\\Prohibition2D\\Assets\\SharedResources\\data.s3db");
            _districtRepository = new DistrictRepository(_context);
            WorkingDistrict = new District();
        }
	
        // Update is called once per frame
        private void Update ()
        {
            if (WorkingDistrict != null)
            {

            }

            Logger.text = String.Format("Population {0}", _population);
        }

        public void PlusOne()
        {
            IEnumerable<DistrictSettings> dadad = _districtRepository.GetAll();
            WorkingDistrict.PlusOne();
            //_context.ExecuteQuery("INSERT INTO Players (Name) VALUES (\'UserCreatedFromUnity\')");
        }
    }
}
