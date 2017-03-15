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
            MainPanel.ShowEcoPanel();
        }

		public void DistillaryButton()
		{
			MainPanel.ShowDistilleryPanel();
		}

		public void PubButton()
		{
			MainPanel.ShowPubPanel();
		}

        public void ArmyButton()
        {
            MainPanel.ShowArmyManagementPanel();
        }

		public void CasinoButton()
		{
			MainPanel.ShowCasinoPanel ();
		}

		public void NightClubButton()
		{
			MainPanel.ShowNightClubPanel ();
		}

		public void LocalBuisnessButton()
		{
			MainPanel.ShowBuisnessPanel ();
		}

        public void CasinoDetailsButton()
        {
            Debug.Log("CasinoDetailsButton");
//            MainPanel.SelectedPanel = PanelType.CasinoPanel;
            try
            {
                Casino casino = _context.GetById<Casino>(1);
                MainPanel.ShowCasinoPanel();
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
            MainPanel.SelectedPanel = PanelType.PubPanel;

            try
            {
                Pub pub = _context.GetById<Pub>(1);
                MainPanel.ShowPubPanel();
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
            var h = 6;
        }
    }
}
