using System;
using System.Collections.Generic;
using Assets.CityScene.Scripts.SubPanels;
using Assets.Model.Buildings;
using Assets.Model.Context;
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
        public EnemyDistrictPanel EnemyDistrictPanel;

        public ISubPanel SelectedPanel;

        private List<MonoBehaviour> _panels;

        private SqliteContext _context;

        public void UpdateDistrict(District district)
        {
            WorkingDistrict = district;
            foreach (var panel in _panels)
            {
                var subPanel = panel as ISubPanel;
                subPanel.UpdateDistrict(district);
            }
        }

        public void SelectPanel(MonoBehaviour monoPanel)
        {
            var panel = monoPanel as ISubPanel;
            if (panel != null)
            {
                panel.UpdateDistrict(WorkingDistrict);
                SelectedPanel = panel;
            }
            HideAllPanels();
            monoPanel.gameObject.SetActive(true);
        }

        public void HideAllPanels()
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
            _panels.Add(EnemyDistrictPanel);

            HideAllPanels();
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
