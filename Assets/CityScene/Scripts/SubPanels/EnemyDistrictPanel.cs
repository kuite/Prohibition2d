using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.CityScene.Scripts.SubPanels
{
    public class EnemyDistrictPanel : MonoBehaviour, ISubPanel
    {
        private District _district;

        public void UpdateDistrict(District district)
        {
            _district = district;
        }

        public void AttackDistrict()
        {
            //todo: get enemy soldiers from memory and attack
            Debug.Log("atacked");
        }
    }
}
