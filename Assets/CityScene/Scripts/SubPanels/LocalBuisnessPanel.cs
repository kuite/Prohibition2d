using Assets.Model.Buildings;
using Assets.Model.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CityScene.Scripts.SubPanels
{
    public class LocalBuisnessPanel : MonoBehaviour, ISubPanel
    {
        public Text LocalBussinesLevel;
        public Text Tribute;

        private District _district;

        private void Update()
        {
            if (_district != null)
            {
                LocalBussinesLevel.text = _district.LocalBussines.Level.ToString();
                Tribute.text = _district.LocalBussines.Tribute.ToString();
            }
        }

        public void UpdateDistrict(District district)
        {
            _district = district;
        }

        public void LevelUp()
        {
            _district.LocalBussines.UpgradeLevel();
        }

        public void LevelDown()
        {
            _district.LocalBussines.DowngradeLevel();
        }

        public void TributeUp()
        {
            _district.LocalBussines.TributeUp();
        }

        public void TributeDown()
        {
            _district.LocalBussines.TributeDown();
        }
    }
}