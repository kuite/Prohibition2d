using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class Distillery : IStructure, IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int AlcoholProduction { get; set; }

        public bool UpgradeAttribute()
        {
            AlcoholProduction++;
            return true;
        }

        public bool DowngradeAttribute()
        {
            AlcoholProduction--;
            return true;
        }
    }
}
