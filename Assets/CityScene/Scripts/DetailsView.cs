using Assets.Model.Buildings;
using Assets.Model.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CityScene.Scripts
{
    public class DetailsView : MonoBehaviour, IDetailsView
    {
        public IStructure Structure;
        public Text Logger;
        public Panel Panel;

        public void UpdateDistrictData(DistrictData districtData)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateType(PanelType type)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateStructure(IStructure structure)
        {
            Structure = structure;
            var g = 5;
        }

        public void UpgradeStructureAttribute()
        {
            Structure.UpgradeAttribute();
        }
    }
}
