using Assets.Model.Buildings;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CityScene.Scripts
{
    public class EcoPanel : MonoBehaviour
    {
        public string PanelType;
        public Text Logger;

        public void MakeVisible()
        {
            
        }

        private void Update()
        {
            Logger.text = PanelType;
        }

        public bool UpgradeAttribute()
        {

            return true;
        }

        public void Save()
        {
            
        }
    }
}
