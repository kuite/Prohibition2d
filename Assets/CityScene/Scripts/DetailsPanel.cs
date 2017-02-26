using Assets.Model.Buildings;
using UnityEngine;

namespace Assets.CityScene.Scripts
{
    public class DetailsPanel : MonoBehaviour
    {
        private IStructure _strustrue;

        public DetailsPanel(IStructure structure)
        {
            _strustrue = structure;
        }

        public bool UpgradeAttribute()
        {

            return _strustrue.UpgradeAttribute();
        }

        public void Save()
        {
            
        }
    }
}
