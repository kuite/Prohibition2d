using UnityEngine;
using UnityEngine.UI;

namespace Assets.CityScene.Scripts.SubPanels
{
    public class DistilleryPanel : MonoBehaviour, ISubPanel
    {
        public Text DistilleryLevel;
        public Text WorkersCount;

        private District _district;

        private void Update()
        {
            if (_district != null)
            {
                DistilleryLevel.text = _district.Distillery.Level.ToString();
                WorkersCount.text = _district.Distillery.Workers.ToString();
            }
        }

        public void UpdateDistrict(District district)
        {
            _district = district;
        }

        public void LevelUp()
        {
            _district.Distillery.UpgradeLevel();
        }

        public void LevelDown()
        {
            _district.Distillery.DowngradeLevel();
        }

        public void WorkersUp()
        {
            _district.Distillery.WorkersUp();
        }

        public void WorkersDown()
        {
            _district.Distillery.WorkersDown();
        }
    }
}
