using System;
using System.Collections.Generic;
using Assets.Model.Buildings;
using Assets.Model.Context;
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
        public PanelType SelectedPanel;
        public EcoPanel EcoPanel;
        public ArmyPanel ArmyPanel;

        private SqliteContext _context;

        // Use this for initialization
        private void Start()
        {
            _context = new SqliteContext("C:\\projects\\Prohibition2D\\Assets\\SharedResources\\data.s3db");
            //WorkingDistrict = new District(_context);
            var gg = _context.Table<DistrictData>();
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
            EcoPanel.gameObject.SetActive(true);
            ArmyPanel.gameObject.SetActive(false);
        }

        public void ShowArmyManagementPanel()
        {
            EcoPanel.gameObject.SetActive(false);
            ArmyPanel.gameObject.SetActive(true);
        }

        public void ShowArmyRecruitPanel()
        {

        }

        public void ShowCasinoPanel()
        {
            Logger.text = "CasinoPanel";
        }

        public void ShowPubPanel()
        {
            Logger.text = "PubPanel";
        }

        public void UpdateDistrict(District district)
        {
            WorkingDistrict = district;
        }
    }
}
