using Assets.Model.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CityScene.Scripts.SubPanels
{
	public class CasinoPanel : MonoBehaviour, ISubPanel
	{
	    public Text CasinoLevel;
	    public Text HomeWin;

	    private District _district;

	    private void Update()
	    {
	        if (_district != null)
	        {
                CasinoLevel.text = _district.Casino.Level.ToString();
                HomeWin.text = _district.Casino.HomeWin.ToString();
            }
	    }

        public void UpdateDistrict(District district)
        {
            _district = district;
        }

	    public void LevelUp()
	    {
	        _district.Casino.UpgradeLevel();
	    }

	    public void LevelDown()
	    {
            _district.Casino.DowngradeLevel();
        }

	    public void HomeWinUp()
	    {
            _district.Casino.HomeWinUp();
        }

        public void HomeWinDown()
        {
            _district.Casino.HomeWinDown();
        }
    }
}
