using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class Casino : Structure
    {
        public double HomeWin { get; set; }

        public bool HomeWinUp()
        {
            HomeWin = HomeWin + 0.01;
            return true;
        }

        public bool HomeWinDown()
        {
            HomeWin = HomeWin - 0.01;
            return true;
        }
    }
}
