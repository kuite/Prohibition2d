using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class Distillery : IStructure
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Level { get; set; }

        public bool UpgradeLevel()
        {
            Level++;
            return true;
        }

        public bool DowngradeLevel()
        {
            Level--;
            return true;
        }
    }
}
