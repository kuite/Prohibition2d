using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class LocalBussines : Structure
    {
        public double Tribute { get; set; }

        public bool TributeUp()
        {
            Tribute = Tribute + 0.01;
            return true;
        }

        public bool TributeDown()
        {
            Tribute = Tribute - 0.01;
            return true;
        }
    }
}
