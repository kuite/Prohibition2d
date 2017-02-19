using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class Distillery
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int AlcoholProduction { get; set; }
    }
}
