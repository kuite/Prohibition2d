using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Model.Context;

namespace Assets.Model.GameSettings
{
    public class SoldierSettings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
