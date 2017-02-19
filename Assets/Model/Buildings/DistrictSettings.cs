using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Model.Context;

namespace Assets.Model.Buildings
{
    public class DistrictSettings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int PubId { get; set; }
        public int NightClubId { get; set; }
        public int DistilleryId { get; set; }
        public int LocalBusinessId { get; set; }
        public int LocalBusinessesCount { get; set; }
        public int CasinoId { get; set; }
    }
}
