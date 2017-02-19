using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class LocalBussines
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TaxRatePercentage { get; set; }
    }
}
