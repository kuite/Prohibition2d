using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class NightClub : IStructure
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Income { get; set; }

        public bool UpgradeLevel()
        {
            Income++;
            return true;
        }

        public bool DowngradeLevel()
        {
            Income--;
            return true;
        }
    }
}
