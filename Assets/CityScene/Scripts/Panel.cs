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

		public PubPanel PubPanel;
        public EcoPanel EcoPanel;
        public ArmyPanel ArmyPanel;
		public DistillertyPanel DistilleryPanel;
		public LocalBuisnessPanel LocalBuisnessPanel;
		public CasinoPanel CasinoPanel;
		public NightClubPanel NightClubPanel;

        private List<MonoBehaviour> _panels;

        private SqliteContext _context;

        // Use this for initialization
        private void Start()
        {
            _panels = new List<MonoBehaviour>();
            _panels.Add(PubPanel);
            _panels.Add(EcoPanel);
            _panels.Add(ArmyPanel);
            _panels.Add(DistilleryPanel);
            _panels.Add(LocalBuisnessPanel);
            _panels.Add(CasinoPanel);
            _panels.Add(NightClubPanel);
        }

        // Update is called once per frame
        private void Update()
        {
            if (WorkingDistrict != null)
            {

            }
        }

        public void ShowSelectedPanel(MonoBehaviour panel)
        {
            HideAllPanels();
            panel.gameObject.SetActive(true);
        }

        private void HideAllPanels()
        {
            _panels.ForEach(p => p.gameObject.SetActive(false));
        }
			
        public void UpdateDistrict(District district)
        {
            WorkingDistrict = district;
        }
    }
}
