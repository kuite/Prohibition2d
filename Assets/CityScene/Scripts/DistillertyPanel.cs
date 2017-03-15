using Assets.Model.Buildings;
using Assets.Model.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CityScene.Scripts
{
	public class DistillertyPanel : MonoBehaviour, IView 
	{
		public string PanelType;
		public Text Logger;

		public void MakeVisible()
		{

		}

		public void UpdateDistrictData(DistrictData districtData)
		{
			throw new System.NotImplementedException();
		}
	}
}
