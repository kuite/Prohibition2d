﻿using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class Distillery : Structure
    {
        public int Workers { get; set; }
        public double WorkerCost { get; set; }

        public bool WorkersUp()
        {
            Workers++;
            return true;
        }

        public bool WorkersDown()
        {
            Workers--;
            return true;
        }
    }
}
