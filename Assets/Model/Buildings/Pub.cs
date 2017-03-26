using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class Pub : Structure
    {
        public int AlcoholPrice { get; set; }

        public bool AlcoholPriceUp()
        {
            AlcoholPrice++;
            return true;
        }

        public bool AlcoholPriceDown()
        {
            AlcoholPrice--;
            return true;
        }
    }
}
