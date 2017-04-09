using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Model.Buildings;
using Assets.Model.Context;
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
            MainPanel.SelectPanel(MainPanel.EcoPanel);
        }

        public void ArmyButton()
        {
            MainPanel.SelectPanel(MainPanel.ArmyPanel);
        }

        public void DistillaryButton()
		{
            MainPanel.SelectPanel(MainPanel.DistilleryPanel);
        }

		public void PubButton()
		{
            MainPanel.SelectPanel(MainPanel.PubPanel);
        }

		public void CasinoButton()
		{
            MainPanel.SelectPanel(MainPanel.CasinoPanel);
        }

		public void NightClubButton()
		{
            MainPanel.SelectPanel(MainPanel.NightClubPanel);
        }

		public void LocalBuisnessButton()
		{
            MainPanel.SelectPanel(MainPanel.LocalBuisnessPanel);
        }
    }
}
