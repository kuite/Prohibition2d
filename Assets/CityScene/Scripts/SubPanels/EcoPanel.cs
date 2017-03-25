using Assets.Model.Buildings;
using Assets.Model.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CityScene.Scripts
{
    public class EcoPanel : MonoBehaviour, ISubPanel
    {
        public string PanelType;
        public Text Logger;

        public void MakeVisible()
        {
            
        }

        public void UpdateDistrict(District districtData)
        {
            throw new System.NotImplementedException();
        }
    }
}
