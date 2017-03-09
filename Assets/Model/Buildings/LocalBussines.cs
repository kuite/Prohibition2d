using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class LocalBussines : IStructure, IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TaxRatePercentage { get; set; }

        public bool UpgradeAttribute()
        {
            TaxRatePercentage++;
            return true;
        }

        public bool DowngradeAttribute()
        {
            TaxRatePercentage--;
            return true;
        }
    }
}
