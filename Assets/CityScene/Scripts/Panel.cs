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
        public EcoPanel EcoPanel;

        private IRepository<DistrictSettings> _districtRepository;
        private SqliteContext _context;
        public int SelectedPanel;

        // Use this for initialization
        private void Start ()
        {
//            _context = new SqliteContext("C:\\projects\\Prohibition2D\\Assets\\SharedResources\\data.s3db");
//            _districtRepository = new DistrictRepository(_context);
//            WorkingDistrict = new District(_context);
        }
	
        // Update is called once per frame
        private void Update ()
        {
            if (WorkingDistrict != null)
            {

            }

            switch (SelectedPanel)
            {
                case 1:
                    EcoPanel.gameObject.SetActive(false);
                    DetailsPanel.gameObject.SetActive(true);
                    Logger.text = "DetailsPanel";
                    break;
                case 2:
                    EcoPanel.gameObject.SetActive(true);
                    DetailsPanel.gameObject.SetActive(false);
                    Logger.text = "EcoPanel";
                    break;
            }
            
        }

//        public void UpgradeAttribute()
//        {
//            IEnumerable<DistrictSettings> dadad = _districtRepository.GetAll();
//            //WorkingDistrict.UpgradeAttribute();
//            //_context.ExecuteQuery("INSERT INTO Players (Name) VALUES (\'UserCreatedFromUnity\')");
//        }

        public void CasioDetailsButton()
        {
            //DetailsPanel = new DetailsPanel(WorkingDistrict.Casino);
        }
    }
}
