using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Model.Context;

namespace Assets.Model.Buildings
{
    public abstract class Structure
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Level { get; set; }

        public bool UpgradeLevel()
        {
            Level++;
            return true;
        }

        public bool DowngradeLevel()
        {
            Level--;
            return true;
        }
    }
}
