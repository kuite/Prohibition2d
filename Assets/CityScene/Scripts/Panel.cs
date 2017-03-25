using System;
using System.Collections.Generic;
using Assets.CityScene.Scripts.SubPanels;
using Assets.Model.Buildings;
using Assets.Model.Context;
using Assets.Model.Views;
using Assets.SceneHelpers;
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
		public DistilleryPanel DistilleryPanel;
		public LocalBuisnessPanel LocalBuisnessPanel;
		public CasinoPanel CasinoPanel;
		public NightClubPanel NightClubPanel;

        private List<MonoBehaviour> _panels;

        private SqliteContext _context;

        public void UpdateDistrict(District district)
        {
            WorkingDistrict = district;
        }

        public void SelectPanel(MonoBehaviour monoPanel)
        {
            HideAllPanels();
            monoPanel.gameObject.SetActive(true);

            var panel = monoPanel as ISubPanel;
            panel.UpdateDistrict(WorkingDistrict);
        }

        private void HideAllPanels()
        {
            _panels.ForEach(p => p.gameObject.SetActive(false));
        }

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

            //todo: For now in UI starting working district is hardcoded (with id = 1)
        }

        // Update is called once per frame
        private void Update()
        {
            if (WorkingDistrict != null)
            {

            }
        }
    }
}
