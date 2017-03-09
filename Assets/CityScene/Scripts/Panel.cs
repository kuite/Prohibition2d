using System;
using System.Collections.Generic;
using Assets.Model.Buildings;
using Assets.Model.Context;
using Assets.Model.Repositories;
using Assets.Model.Views;
using Assets.SharedResources.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CityScene.Scripts
{
    public class Panel : MonoBehaviour
    {
        public District WorkingDistrict;
        public Text Logger;
        public DetailsView DetailsView;
        public EcoView EcoView;
        public ArmyView ArmyView;

        public PanelType SelectedPanel;

        private IRepository<DistrictData> _districtRepository;
        private SqliteContext _context;

        // Use this for initialization
        private void Start()
        {
            // = new SqliteContext("C:\\projects\\Prohibition2D\\Assets\\SharedResources\\data.s3db");
            //_districtRepository = new DistrictDataRepository(_context);
            //WorkingDistrict = new District(_context);
            var h = 6;
        }

        // Update is called once per frame
        private void Update()
        {
            if (WorkingDistrict != null)
            {

            }
        }

        public void ShowEcoPanel()
        {
            
        }

        public void ShowArmyPanel()
        {
            
        }

        public void ShowCasinoView()
        {
            EcoView.gameObject.SetActive(false);
            DetailsView.gameObject.SetActive(true);
            DetailsView.Panel = this;
            Logger.text = "CasinoPanel";
        }

        public void ShowPubView()
        {
            EcoView.gameObject.SetActive(true);
            DetailsView.gameObject.SetActive(false);
            DetailsView.Panel = this;
            Logger.text = "PubPanel";
        }

        public void UpgradeAttribute()
        {
            DetailsView.Structure.UpgradeAttribute();
            //WorkingDistrict.UpgradeAttribute();
            //_context.ExecuteQuery("INSERT INTO Players (Name) VALUES (\'UserCreatedFromUnity\')");
        }
    }
}
