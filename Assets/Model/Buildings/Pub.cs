using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class Pub
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int AlcoholPrice { get; set; }
        public int Income { get; private set; }
    }
}
