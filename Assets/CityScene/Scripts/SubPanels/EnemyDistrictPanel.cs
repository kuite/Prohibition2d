using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.SceneHelpers;

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
			MemoryHolder.GetInstance ().AttackedDistrict = _district.InstanceId;
			Debug.Log("Attacking district: " + _district.InstanceId.ToString());
			SceneManager.LoadScene ("StartFightScene");
            //todo: get enemy soldiers from memory and attack
        }
    }
}
