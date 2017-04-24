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
			if(FindNeighbour()){
				MemoryHolder.GetInstance ().AttackedDistrict = _district.InstanceId;
				Debug.Log("Attacking district: " + _district.InstanceId.ToString());
				SceneManager.LoadScene ("StartFightScene");
				//todo: get enemy soldiers from memory and attack
			}
        }

		bool FindNeighbour(){
			foreach (int DistId in MemoryHolder.GetInstance ().UserDistricts) {
				Vector2 PretenderPosition = new Vector2 (0,0);
				PretenderPosition = MemoryHolder.GetInstance ().CaschedDistricts [DistId].position;
				if (PretenderPosition.x == _district.position.x) {
					if (PretenderPosition.y + 1.0f == _district.position.y || PretenderPosition.y - 1.0f == _district.position.y) {
						return true;
					}
				} else if (PretenderPosition.y == _district.position.y) {
					if (PretenderPosition.x + 1.0f == _district.position.x || PretenderPosition.x - 1.0f == _district.position.x) {
						return true;
					}
				}
			}
			return false;
		}
    }
}
