using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class LocalBussines : IStructure
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TaxRatePercentage { get; set; }

        public bool UpgradeLevel()
        {
            TaxRatePercentage++;
            return true;
        }

        public bool DowngradeLevel()
        {
            TaxRatePercentage--;
            return true;
        }

    }
}
