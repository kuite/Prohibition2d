using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class Casino : IStructure
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int WinMarginPercentage { get; set; }

        public bool UpgradeAttribute()
        {
            WinMarginPercentage++;
            return true;
        }

        public bool DowngradeAttribute()
        {
            WinMarginPercentage--;
            return true;
        }
    }
}
