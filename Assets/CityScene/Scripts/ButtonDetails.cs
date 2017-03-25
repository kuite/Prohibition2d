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

        // Use this for initialization
        private void Start()
        {

        }

        public void EcoButton()
        {
            MainPanel.ShowSelectedPanel(MainPanel.EcoPanel);
        }

        public void ArmyButton()
        {
            MainPanel.ShowSelectedPanel(MainPanel.ArmyPanel);
        }

        public void DistillaryButton()
		{
            MainPanel.ShowSelectedPanel(MainPanel.DistilleryPanel);
            MainPanel.UpdateDistrictPanel(MainPanel.CasinoPanel);
        }

		public void PubButton()
		{
            MainPanel.ShowSelectedPanel(MainPanel.PubPanel);
            MainPanel.UpdateDistrictPanel(MainPanel.PubPanel);
        }

		public void CasinoButton()
		{
            MainPanel.ShowSelectedPanel(MainPanel.CasinoPanel);
            MainPanel.UpdateDistrictPanel(MainPanel.CasinoPanel);
        }

		public void NightClubButton()
		{
            MainPanel.ShowSelectedPanel(MainPanel.NightClubPanel);
            MainPanel.UpdateDistrictPanel(MainPanel.NightClubPanel);
        }

		public void LocalBuisnessButton()
		{
            MainPanel.ShowSelectedPanel(MainPanel.LocalBuisnessPanel);
            MainPanel.UpdateDistrictPanel(MainPanel.LocalBuisnessPanel);
        }
    }
}
