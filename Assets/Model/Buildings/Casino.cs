using Assets.Model.Context;
using UnityEngine;

namespace Assets.Model.Buildings
{
    public class Casino
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int WinMarginPercentage { get; set; }
    }
}
