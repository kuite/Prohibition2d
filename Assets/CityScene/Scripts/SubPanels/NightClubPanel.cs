using Assets.Model.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CityScene.Scripts.SubPanels
{
    public class NightClubPanel : MonoBehaviour, ISubPanel
    {
        public Text NightClubLevel;
        public Text GirlsCount;

        private District _district;

        private void Update()
        {
            if (_district != null)
            {
                NightClubLevel.text = _district.NightClub.Level.ToString();
                GirlsCount.text = _district.NightClub.Girls.ToString();
            }
        }

        public void UpdateDistrict(District district)
        {
            _district = district;
        }

        public void LevelUp()
        {
            _district.NightClub.UpgradeLevel();
        }

        public void LevelDown()
        {
            _district.NightClub.DowngradeLevel();
        }

        public void GirlsUp()
        {
            _district.NightClub.GirlsUp();
        }

        public void GirlsDown()
        {
            _district.NightClub.GirlsDown();
        }
    }
}
