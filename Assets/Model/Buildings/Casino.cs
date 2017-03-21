using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class Casino : IStructure
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int WinMarginPercentage { get; set; }

        public bool UpgradeLevel()
        {
            WinMarginPercentage++;
            return true;
        }

        public bool DowngradeLevel()
        {
            WinMarginPercentage--;
            return true;
        }
    }
}
