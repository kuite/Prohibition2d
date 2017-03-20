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
		public PubPanel PubPanel;
        public EcoPanel EcoPanel;
        public ArmyPanel ArmyPanel;
		public DistillertyPanel DistilleryPanel;
		public LocalBuisness LocalBuisness;
		public CasinoPanel CasinoPanel;
		public NightClubPanel NightClubPanel;


        private SqliteContext _context;

        // Use this for initialization
        private void Start()
        {
            //_context = new SqliteContext("C:\\projects\\Prohibition2D\\Assets\\SharedResources\\data.s3db");
            _context = new SqliteContext(Application.dataPath + "\\SharedResources\\data.s3db");
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
			EcoPanel.gameObject.SetActive			(true);
			DistilleryPanel.gameObject.SetActive	(false);
            ArmyPanel.gameObject.SetActive			(false);
			PubPanel.gameObject.SetActive			(false);
			LocalBuisness.gameObject.SetActive		(false);
			NightClubPanel.gameObject.SetActive		(false);
			CasinoPanel.gameObject.SetActive		(false);
        }

		public void ShowDistilleryPanel()
		{
			DistilleryPanel.gameObject.SetActive	(true);
			ArmyPanel.gameObject.SetActive			(false);
			EcoPanel.gameObject.SetActive			(false);
			PubPanel.gameObject.SetActive			(false);
			LocalBuisness.gameObject.SetActive		(false);
			NightClubPanel.gameObject.SetActive		(false);
			CasinoPanel.gameObject.SetActive		(false);
		}

		public void ShowPubPanel()
		{
			PubPanel.gameObject.SetActive			(true);
			DistilleryPanel.gameObject.SetActive	(false);
			ArmyPanel.gameObject.SetActive			(false);
			EcoPanel.gameObject.SetActive			(false);
			LocalBuisness.gameObject.SetActive		(false);
			NightClubPanel.gameObject.SetActive		(false);
			CasinoPanel.gameObject.SetActive		(false);
		}

        public void ShowArmyManagementPanel()
        {
			ArmyPanel.gameObject.SetActive			(true);
			EcoPanel.gameObject.SetActive			(false);
			DistilleryPanel.gameObject.SetActive	(false);
			PubPanel.gameObject.SetActive			(false);
			LocalBuisness.gameObject.SetActive		(false);
			NightClubPanel.gameObject.SetActive		(false);
			CasinoPanel.gameObject.SetActive		(false);
        }

		public void ShowBuisnessPanel()
		{
			LocalBuisness.gameObject.SetActive		(true);
			ArmyPanel.gameObject.SetActive			(false);
			EcoPanel.gameObject.SetActive			(false);
			DistilleryPanel.gameObject.SetActive	(false);
			PubPanel.gameObject.SetActive			(false);
			NightClubPanel.gameObject.SetActive		(false);
			CasinoPanel.gameObject.SetActive		(false);
		}

		public void ShowNightClubPanel()
		{
			NightClubPanel.gameObject.SetActive		(true);
			LocalBuisness.gameObject.SetActive		(false);
			ArmyPanel.gameObject.SetActive			(false);
			EcoPanel.gameObject.SetActive			(false);
			DistilleryPanel.gameObject.SetActive	(false);
			PubPanel.gameObject.SetActive			(false);
			CasinoPanel.gameObject.SetActive		(false);
		}

		public void ShowCasinoPanel()
		{
			CasinoPanel.gameObject.SetActive		(true);
			LocalBuisness.gameObject.SetActive		(false);
			ArmyPanel.gameObject.SetActive			(false);
			EcoPanel.gameObject.SetActive			(false);
			DistilleryPanel.gameObject.SetActive	(false);
			PubPanel.gameObject.SetActive			(false);
			NightClubPanel.gameObject.SetActive		(false);
		}

        public void ShowArmyRecruitPanel()
        {

        }
			
        public void UpdateDistrict(District district)
        {
            WorkingDistrict = district;
        }
    }
}
