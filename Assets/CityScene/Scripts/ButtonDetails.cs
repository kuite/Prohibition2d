using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Model.Buildings;
using Assets.Model.Context;
using Assets.Model.Views;
using UnityEngine;

namespace Assets.CityScene.Scripts
{
    public class ButtonDetails : MonoBehaviour
    {
        public Panel MainPanel;

        private SqliteContext _context;


        // Use this for initialization
        private void Start()
        {
            //_context = new SqliteContext("C:\\projects\\Prohibition2D\\Assets\\SharedResources\\data.s3db");
            //_districtRepository = new DistrictDataRepository(_context);
            //WorkingDistrict = new District(_context);
            var h = 5;
        }

        public void EcoButton()
        {
            MainPanel.ShowSelectedPanel(MainPanel.EcoPanel);
        }

		public void DistillaryButton()
		{
            MainPanel.ShowSelectedPanel(MainPanel.DistilleryPanel);
        }

		public void PubButton()
		{
            MainPanel.ShowSelectedPanel(MainPanel.PubPanel);
        }

        public void ArmyButton()
        {
            MainPanel.ShowSelectedPanel(MainPanel.ArmyPanel);
        }

		public void CasinoButton()
		{
            MainPanel.ShowSelectedPanel(MainPanel.CasinoPanel);
        }

		public void NightClubButton()
		{
            MainPanel.ShowSelectedPanel(MainPanel.NightClubPanel);
        }

		public void LocalBuisnessButton()
		{
            MainPanel.ShowSelectedPanel(MainPanel.LocalBuisnessPanel);
        }

        public void CasinoDetailsButton()
        {
            Debug.Log("CasinoDetailsButton");
//            MainPanel.SelectedPanel = PanelType.CasinoPanel;
            try
            {
                Casino casino = _context.GetById<Casino>(1);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
            var h = 6;
        }

        public void PubDetailsButton()
        {
            Debug.Log("PubDetailsButton");

            try
            {
                Pub pub = _context.GetById<Pub>(1);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
            var h = 6;
        }
    }
}
