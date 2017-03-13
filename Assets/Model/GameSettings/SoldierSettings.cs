using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Model.Context;

namespace Assets.Model.GameSettings
{
    public class SoldierSettings : IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
