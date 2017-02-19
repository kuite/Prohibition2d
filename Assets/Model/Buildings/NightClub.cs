using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class NightClub
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Income { get; set; }
    }
}
