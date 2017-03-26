using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class NightClub : Structure
    {
        public int Girls { get; set; }

        public bool GirlsUp()
        {
            Girls++;
            return true;
        }

        public bool GirlsDown()
        {
            Girls--;
            return true;
        }
    }
}
