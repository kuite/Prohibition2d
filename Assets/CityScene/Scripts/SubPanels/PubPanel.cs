using Assets.Model.Buildings;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CityScene.Scripts.SubPanels
{
    public class PubPanel : MonoBehaviour, ISubPanel
    {
        public Text PubLevel;
        public Text AlcoholPrice;

        private District _district;

        private void Update()
        {
            if (_district != null)
            {
                PubLevel.text = _district.Pub.Level.ToString();
                AlcoholPrice.text = _district.Pub.AlcoholPrice.ToString();
            }
        }

        public void UpdateDistrict(District district)
        {
            _district = district;
        }

        public void LevelUp()
        {
            _district.Pub.UpgradeLevel();
        }

        public void LevelDown()
        {
            _district.Pub.DowngradeLevel();
        }

        public void AlcoholPriceUp()
        {
            _district.Pub.AlcoholPriceUp();
        }

        public void AlcoholPriceDown()
        {
            _district.Pub.AlcoholPriceDown();
        }
    }
}