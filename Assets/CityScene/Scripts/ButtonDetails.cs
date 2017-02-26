using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.CityScene.Scripts
{
    public class ButtonDetails : MonoBehaviour
    {
        public Panel MainPanel;

        public void CasinoDetailsButton()
        {
            Debug.Log("CasinoDetailsButton");
            MainPanel.SelectedPanel = 1;
        }

        public void PubDetailsButton()
        {
            Debug.Log("PubDetailsButton");
            MainPanel.SelectedPanel = 2;
        }
    }
}
