using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Model.Buildings;
using Assets.Model.Context;
using Assets.Model.Repositories;
using Assets.Model.Views;
using UnityEngine;

namespace Assets.CityScene.Scripts
{
    public class ButtonDetails : MonoBehaviour
    {
        public Panel MainPanel;

        private SqliteContext _context;
        private CasinoRepository _casinoRepository;
        private PubRepository _pubRepository;

        // Use this for initialization
        private void Start()
        {
            _context = new SqliteContext("C:\\projects\\Prohibition2D\\Assets\\SharedResources\\data.s3db");
            //_districtRepository = new DistrictDataRepository(_context);
            _casinoRepository = new CasinoRepository(_context);
            _pubRepository = new PubRepository(_context);
            //WorkingDistrict = new District(_context);
            var h = 5;
        }

        public void EcoButton()
        {
            MainPanel.ShowEcoPanel();
        }

        public void ArmyButton()
        {
            MainPanel.ShowArmyPanel();
        }

        public void CasinoDetailsButton()
        {
            Debug.Log("CasinoDetailsButton");
//            MainPanel.SelectedPanel = PanelType.CasinoPanel;
            if (_casinoRepository == null)
            {
                _casinoRepository = new CasinoRepository(_context);
            }
            try
            {
                Casino casino = _casinoRepository.GetById(1);
                MainPanel.DetailsView.UpdateStructure(casino);
                MainPanel.ShowDetailedView();
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

            if (_casinoRepository == null)
            {
                _casinoRepository = new CasinoRepository(_context);
            }
            try
            {
                Pub pub = _pubRepository.GetById(1);
                MainPanel.DetailsView.UpdateStructure(pub);
                MainPanel.ShowDetailedView();
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
            var h = 6;
        }
    }
}
