using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class Pub : IStructure
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int AlcoholPrice { get; set; }
        public int Income { get; private set; }

        public bool UpgradeAttribute()
        {
            throw new System.NotImplementedException();
        }

        public bool DowngradeAttribute()
        {
            throw new System.NotImplementedException();
        }
    }
}
