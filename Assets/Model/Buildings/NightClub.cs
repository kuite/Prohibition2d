using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class NightClub : IStructure, IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Income { get; set; }

        public bool UpgradeAttribute()
        {
            Income++;
            return true;
        }

        public bool DowngradeAttribute()
        {
            Income--;
            return true;
        }
    }
}
